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
	public static LevelController controller;

	//canvas - needed for adding children to canvas
	public GameObject canvas;

	//stars/progress panel
	public int starsEarned;
	public int MoneyFor1Star;
	public int packagesFor1Star;
	public int maxObjectsUsedFor1Star;
	public int currentObjectCount;

	//pause/play
	public bool isPlaying = false;

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
	private int successfulPackages;
	private int failurePackages;
	private int currentMoney;

	public int SuccessfulPackages{
		get{ return successfulPackages; }
		set{ successfulPackages = value; }
	}
	public int FailurePackages{
		get{ return failurePackages; }
		set{ failurePackages = value; }
	}
	public int CurrentMoney{
		get{ return currentMoney; }
		set{ currentMoney = value; }
	}

	//object panel
	private GameObject selectedObject;
	public bool isObjectPanelActive;

	public GameObject SelectedObject{
		get{ return selectedObject; }
		set{ selectedObject = value; }
	}

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