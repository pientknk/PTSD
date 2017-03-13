using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBank : MonoBehaviour {
	public static int startingMoney = 4000;
	public static int currentMoney = 4000;
	public static int conveyorCost = 500;
	public static int trampolineCost = 350;
	public static int slideCost = 250;
	public static int fanCost = 300;
	public static int filterCost = 200;

	public int StartingMoney{
		get{
			return startingMoney;
		}
		set{
			startingMoney = value;
		}
	}
	public int CurrentMoney{
		get{
			return currentMoney;
		}
		set{
			currentMoney = value;
		}
	}
	public int ConveyorCost{
		get{
			return conveyorCost;
		}
		set{
			conveyorCost = value;		
		}
	}
	public int TrampolineCost{
		get{
			return trampolineCost;
		}
		set{
			trampolineCost = value;
		}
	}
	public int SlideCost{
		get{
			return slideCost;
		}
		set{
			slideCost = value;
		}
	}
	public int FanCost{
		get{
			return fanCost;
		}
		set{
			fanCost = value;
		}
	}
	public int FilterCost{
		get{
			return filterCost;
		}
		set{
			filterCost = value;
		}
	}


	public void subtractMoney(int amount){
		if(amount > currentMoney){
			currentMoney = 0;
		} else{
			currentMoney -= amount;
		}
	}

	public void addMoney(int amount){
		currentMoney += amount;
	}

	public bool canBuyConveyor(){
		if (currentMoney >= conveyorCost) {
			return true;
		}
		return false;
	}

	public bool canBuyTrampoline(){
		if (currentMoney >= trampolineCost) {
			return true;
		}
		return false;
	}

	public bool canBuySlide(){
		if (currentMoney >= slideCost) {
			return true;
		}
		return false;
	}

	public bool canBuyFan(){
		if (currentMoney >= fanCost) {
			return true;
		}
		return false;
	}

	public bool canbBuyFilter(){
		if (currentMoney >= fanCost) {
			return true;
		}
		return false;
	}
}
