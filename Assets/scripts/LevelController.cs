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

	private GameObject canvas;
	/// <summary>
	/// The main canvas which should be the parent for all spawned objects.
	/// </summary>
	public GameObject Canvas{
		get{ return canvas; }
		set{ canvas = value; }
	}
		
	private int starsEarned;
	/// <summary>
	/// The stars earned for this level, determined by the 3 tracked progresses: money earned, packages delivered, 
	/// and number of objects used.
	/// </summary>
	public int StarsEarned{
		get{ return starsEarned; }
		set{ starsEarned = value; }
	}
	private int moneyFor1Star;
	/// <summary>
	/// The money needed in order to earn 1 star for this level.
	/// </summary>
	public int MoneyFor1Star{
		get{ return moneyFor1Star; }
		set{ moneyFor1Star = value; }
	}
	private int packagesFor1Star;
	/// <summary>
	/// The number of packages delivered to earn 1 star for this level.
	/// </summary>
	public int PackagesFor1Star{
		get{ return packagesFor1Star; }
		set{ packagesFor1Star = value; }
	}
	private int maxObjectsUsedFor1Star;
	/// <summary>
	/// The max number of objects a player can use before losing 1 star for this level.
	/// </summary>
	public int MaxObjectsUsedFor1Star{
		get{ return maxObjectsUsedFor1Star; }
		set{ maxObjectsUsedFor1Star = value; }
	}
	private int currentObjectCount;
	/// <summary>
	/// The current amount of bought objects on the level, compared against maxObjectsUsedFor1Star.
	/// </summary>
	public int CurrentObjectCount{
		get{ return currentObjectCount; }
		set{ currentObjectCount = value; }
	}

	//pause/play
	private float currentGameSpeed = 0.0f;
	/// <summary>
	/// The current game speed, set by the various play/pause buttons, where 0 means the game is "paused"
	/// </summary>
	public float CurrentGameSpeed{
		get{ return currentGameSpeed; }
		set{ currentGameSpeed = value; }
	}

	//money
	private int startingMoney = 4000;
	/// <summary>
	/// The amount of money the player gets when the level first loads and is all the money they can spend on objects.
	/// </summary>
	public int StartingMoney{
		get{ return startingMoney; }
		set{ startingMoney = value; }
	}
	private int currentMoney;
	/// <summary>
	/// How much money the player has earned or lost as they play the level.
	/// </summary>
	public int CurrentMoney{
		get{ return currentMoney; }
		set{ currentMoney = value; }
	}

	//buyable items - the cost for every object
	private int conveyorCost = 500;
	/// <summary>
	/// The cost to buy one conveyor.
	/// </summary>
	public int ConveyorCost{
		get{ return conveyorCost; }
		set{ conveyorCost = value; }
	}
	private int trampolineCost = 350;
	/// <summary>
	/// The cost to buy one trampoline.
	/// </summary>
	public int TrampolineCost{
		get{ return trampolineCost; }
		set{ trampolineCost = value; }
	}
	private int slideCost = 250;
	/// <summary>
	/// The cost to buy one slide.
	/// </summary>
	public int SlideCost{
		get{ return slideCost; }
		set{ slideCost = value; }
	}
	private int fanCost = 300;
	/// <summary>
	/// The cost to buy one fan.
	/// </summary>
	public int FanCost{
		get{ return fanCost; }
		set{ fanCost = value; }
	}


	//create packages
	public List<GameObject> allPackages;
	public int numPackagesLeft;
	public float spawnTime;
	public bool autoPickPackages;
	public List<GameObject> spawnPoints;

	//delivered packages/progresses
	public int successfulPackages;
	public int failurePackages;

	//object panel
	public GameObject selectedObject;
	public bool isObjectPanelActive;

	//inventroy panel
	public bool isShopPanelActive = false;

	//menu panel
	public bool isMenuPanelActive = false;

	//called before any start methods
	void Awake () {
		controller = this;
	}

	//saves data out to a binary file
	public void Save(){
		//open file where data will be saved
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".dat");

		// update the file to be saved by getting current user data
		LevelData data = new LevelData();
		data.canvas = canvas;
		data.starsEarned = starsEarned;
		data.MoneyFor1Star = MoneyFor1Star;
		data.packagesFor1Star = packagesFor1Star;


		//write to file and close it
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(Scene scene){
		if (File.Exists (Application.persistentDataPath + "/" + scene.name + ".dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + scene.name + ".dat", FileMode.Open);
			LevelData data = (LevelData)bf.Deserialize (file);
			file.Close();

			starsEarned = data.starsEarned;
			MoneyFor1Star = data.MoneyFor1Star;
		}
	}
}

[Serializable]
class LevelData{
	//static instance used for other scripts to reference
	public static LevelController controller;

	//canvas
	public GameObject canvas;

	//stars/progress panel
	public int starsEarned;
	public int MoneyFor1Star;
	public int packagesFor1Star;
	public int maxObjectsUsedFor1Star;
	public int currentObjectCount;

	//pause/play
	public bool isPlaying;

	//money
	public int startingMoney = 4000;

	//buyable items
	public int conveyorCost = 500;
	public int trampolineCost = 350;
	public int slideCost = 250;
	public int fanCost = 300;


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
	public bool isActive;
}