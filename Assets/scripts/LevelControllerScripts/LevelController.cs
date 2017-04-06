using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

/* Should be attached to 'Level Manager' which should exist on every level to manage that specific level by 
 * setting instance variables that will be referenced by all other objects */
public class LevelController : MonoBehaviour {

	//static instance used for other scripts to reference
	public static LevelController instance;
	/// <summary>
	/// The main canvas which should be the parent for all spawned objects.
	/// </summary>
	public GameObject canvas;
	/// <summary>
	/// The GameObject that holds all the objects besides the ui canvas
	/// </summary>
	public GameObject theLevelObjects;
	/// <summary>
	/// The canvas overlapping theLevelObjects in order for ui elements to overlap the game objects such as the 
	/// show selected object and package damage indicator to work correctly.
	/// </summary>
	public GameObject levelCanvas;
	/// <summary>
	/// The object panel to update and modify objects.
	/// </summary>
	public GameObject objectPanel;
	/// <summary>
	/// The summary canvas is the canvas that overlays the camera with a summary of how the player did for this level,
	/// and should only be set active after all packages have been destroyed.
	/// </summary>
	public GameObject summaryCanvas;
	/// <summary>
	/// The stars earned for this level, determined by the 3 tracked progresses: money earned, packages delivered, 
	/// and number of objects used.
	/// </summary>	
	public int starsEarned;
	/// <summary>
	/// The money needed in order to earn 1 star for this level.
	/// </summary>
	public int moneyFor1Star = 1500;
	/// <summary>
	/// The number of packages delivered to earn 1 star for this level.
	/// </summary>
	public int packagesFor1Star = 25;
	/// <summary>
	/// The max number of objects a player can use before losing 1 star for this level.
	/// </summary>
	public int maxObjectsUsedFor1Star = 15;
	/// <summary>
	/// The current amount of bought objects on the level, compared against maxObjectsUsedFor1Star.
	/// </summary>
	public int currentObjectCount;

	//money
	/// <summary>
	/// The amount of money the player gets when the level first loads and is all the money they can spend on objects. 
	/// Should be updated whenever the user buys or sells something.
	/// </summary>
	public int startingMoney = 4000;
	/// <summary>
	/// How much money the player has earned or lost as they play the level.
	/// </summary>
	public int currentMoney;

	//buyable items - the cost for every object
	/// <summary>
	/// The cost to buy one conveyor.
	/// </summary>
	public int conveyorCost = 500;
	/// <summary>
	/// The cost to buy one trampoline.
	/// </summary>
	public int trampolineCost = 350;
	/// <summary>
	/// The cost to buy one slide.
	/// </summary>
	public int slideCost = 250;
	/// <summary>
	/// The cost to buy one funnel.
	/// </summary>
	public int funnelCost = 300;
	/// <summary>
	/// The cost to buy one fan.
	/// </summary>
	public int fanCost = 300;
	/// <summary>
	/// Thec cost to buy one glue.
	/// </summary>
	public int glueCost = 350;
	/// <summary>
	/// The cost to buy one magnet.
	/// </summary>
	public int magnetCost = 300;
	//packages
	/// <summary>
	/// The amount of money a regular package cost.
	/// </summary>
	public float packageWorth = 100.0f;
	/// <summary>
	/// The paused game speed when the level starts and when the pause button is hit.
	/// </summary>
	public float pauseGameSpeed = 0.0f;
	/// <summary>
	/// The regular game speed when the play button is hit.
	/// </summary>
	public float regularGameSpeed = 1.0f;
	/// <summary>
	/// The fast game speed when the fast play button is hit.
	/// </summary>
	public float fastGameSpeed = 2.0f;
	/// <summary>
	/// The super fast game speed when the super fast button is hit.
	/// </summary>
	public float superGameSpeed = 3.0f;
	//pause/play
	/// <summary>
	/// The bool to keep track of whether or not the level is paused.
	/// </summary>
	public bool isPaused = true;
	/// <summary>
	/// A reference to all of the objects bought by the player. Used to recreate a saved level.
	/// </summary>
	public List<GameObject> allBoughtObjects;
	/// <summary>
	/// All packages that will spawn for this level.
	/// </summary>
	public List<GameObject> allPackages;
	/// <summary>
	/// All the package types that can spawn on this level, ex. box blue and box orange.
	/// </summary>
	public List<GameObject> packageTypes;
	/// <summary>
	/// The number of packages left to spawn before its the end of the level.
	/// </summary>
	private int numPackagesLeft;
	public int NumPackagesLeft{
		get{ return numPackagesLeft; }
		set{ numPackagesLeft = value; }
	}
	private int packagesDestroyed;
	public int PackagesDestroyed{
		get{ return packagesDestroyed; }
		set{ packagesDestroyed = value; }
	}
	/// <summary>
	/// The time in seconds between packages spawning
	/// </summary>
	public float spawnTime = 3.0f;
	/// <summary>
	/// The time that the game has been played, used for spawning packages on time
	/// </summary>
	private float timeCounter;
	public float TimeCounter{
		get{ return timeCounter; }
		set{ timeCounter = value; }
	}
	/// <summary>
	/// True if the packages for this level should be randomly generated, else false for manual selection of packages.
	/// </summary>
	public bool autoPickPackages = false;
	/// <summary>
	/// The objects where packages should spawn from, must be 1 or more
	/// </summary>
	public List<GameObject> spawnPoints;
	/// <summary>
	/// True if the spawn points should infinitely create packages to keep spawning.
	/// </summary>
	public bool infiniteCreate = false;

	//delivered packages/progresses
	/// <summary>
	/// The count of packages successfully delivered.
	/// </summary>
	private int successfulPackages;
	public int SuccessfulPackages{
		get{ return successfulPackages; }
		set{ successfulPackages = value; }
	}
	/// <summary>
	/// The count of packages that were not successfully delivered (destroyed or dropped into the wrong truck)
	/// </summary>
	private int failurePackages;
	public int FailurePackages{
		get{ return failurePackages; }
		set{ failurePackages = value; }
	}

	//object panel
	/// <summary>
	/// The current object selected, this object can then be modified by the object panel.
	/// </summary>
	public GameObject selectedObject = null;
	/// <summary>
	/// True if the object panel should be active and showing, else false to hide it.
	/// </summary>
	public bool isObjectPanelActive = false;
	//inventroy panel
	/// <summary>
	/// True if the inventory panel should be active, else false to hide it.
	/// </summary>
	public bool isShopPanelActive = false;

	//menu panel
	/// <summary>
	/// True if the menu panel should be active, else false to hide it.
	/// </summary>
	public bool isMenuPanelActive = false;

	//called before any start methods
	void Awake () {
		instance = this;
	}

	void Start(){
		numPackagesLeft = allPackages.Count;
	}
		
	public void AutoGenerate(){
		if (autoPickPackages) {
			for (int z = 0; z < allPackages.Count; z++) {
				//pick a random package from all the possible packages on the level
				int random = UnityEngine.Random.Range (0, packageTypes.Count);
				allPackages [z] = packageTypes [random];
			}
		}
	}

	//saves data out to a binary file
	/// <summary>
	/// Save this scene's data and write it to a binary file
	/// </summary>
	public void Save(){
		//open file where data will be saved
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".dat");

		// update the file to be saved by getting current user data
		LevelData data = new LevelData();
		data.canvas = canvas;
		data.starsEarned = starsEarned;
		data.moneyFor1Star = moneyFor1Star;
		data.packagesFor1Star = packagesFor1Star;
		data.maxObjectsUsedFor1Star = maxObjectsUsedFor1Star;
		data.currentObjectCount = currentObjectCount;
		data.startingMoney = startingMoney;
		data.currentMoney = currentMoney;
		data.conveyorCost = conveyorCost;
		data.slideCost = slideCost;
		data.trampolineCost = trampolineCost;
		data.fanCost = fanCost;
		data.allPackages = allPackages;
		data.numPackagesLeft = numPackagesLeft;
		data.spawnTime = spawnTime;
		data.autoPickPackages = autoPickPackages;
		data.spawnPoints = spawnPoints;
		data.successfulPackages = successfulPackages;
		data.failurePackages = failurePackages;
		data.selectedObject = null;
		data.isObjectPanelActive = false;
		data.isMenuPanelActive = false;
		data.isShopPanelActive = false;


		//write to file and close it
		bf.Serialize (file, data);
		file.Close ();
	}

	/// <summary>
	/// Load the specified scene by using it's name and searchign for its binary file to load data from. 
	/// </summary>
	/// <param name="scene">Scene.</param>
	public void Load(Scene scene){
		if (File.Exists (Application.persistentDataPath + "/" + scene.name + ".dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + scene.name + ".dat", FileMode.Open);
			LevelData data = (LevelData)bf.Deserialize (file);
			file.Close ();

			//load all the data from the save file
			starsEarned = data.starsEarned;
			moneyFor1Star = data.moneyFor1Star;
			packagesFor1Star = data.packagesFor1Star;
			maxObjectsUsedFor1Star = data.maxObjectsUsedFor1Star;
			currentObjectCount = data.currentObjectCount;
			startingMoney = data.startingMoney;
			currentMoney = data.currentMoney;
			conveyorCost = data.conveyorCost;
			trampolineCost = data.trampolineCost;
			slideCost = data.slideCost;
			fanCost = data.fanCost;
			allPackages = data.allPackages;
			numPackagesLeft = data.numPackagesLeft;
			spawnTime = data.spawnTime;
			autoPickPackages = data.autoPickPackages;
			spawnPoints = data.spawnPoints;
			successfulPackages = data.successfulPackages;
			failurePackages = data.failurePackages;
			selectedObject = data.selectedObject;
			isObjectPanelActive = data.isObjectPanelActive;
			isMenuPanelActive = data.isMenuPanelActive;
			isShopPanelActive = data.isShopPanelActive;
		} 
		SceneManager.LoadScene (scene.name);
	}
}

[Serializable]
class LevelData{
	//canvas
	public GameObject canvas;

	//stars/progress panel
	public int starsEarned;
	public int moneyFor1Star;
	public int packagesFor1Star;
	public int maxObjectsUsedFor1Star;
	public int currentObjectCount;

	//pause/play

	//money
	public int startingMoney;

	//buyable items
	public int conveyorCost;
	public int trampolineCost;
	public int slideCost;
	public int fanCost;


	//create packages
	public List<GameObject> allPackages;
	public int numPackagesLeft;
	public float spawnTime;
	public bool autoPickPackages;
	public List<GameObject> spawnPoints;

	//delivered packages/progresses
	public int successfulPackages;
	public int failurePackages;
	public int currentMoney;

	//object panel
	public GameObject selectedObject;

	//panel active
	public bool isObjectPanelActive;
	public bool isShopPanelActive;
	public bool isMenuPanelActive;
}