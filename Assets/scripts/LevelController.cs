using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Should be attached to 'Level Manager' which should exist on every level to manage that specific level by 
 * setting instance variables that will be referenced by all other objects */
public class LevelController : MonoBehaviour {

	//static instance used for other scripts to reference
	public static LevelController controller;

	//canvas
	public GameObject canvas;

	//stars
	public int starsEarned;
	public int MoneyFor1Star;
	public int packagesFor1Star;
	public int maxObjectsUsedFor1Star;

	//pause/play
	public bool isPlaying;

	//money
	public int currentEarnedMoney;
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
	public bool isActive;

	public GameObject SelectedObject{
		get{ return selectedObject; }
		set{ selectedObject = value; }
	}

	//called before any start methods
	void Awake () {
		controller = this;
	}
}
