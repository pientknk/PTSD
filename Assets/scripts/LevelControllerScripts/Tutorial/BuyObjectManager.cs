using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyObjectManager : MonoBehaviour {

	private Button allButtons;

	// Use this for initialization
	void Start () {
		allButtons = gameObject.GetComponentInChildren<Button> ();
	}

	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.IsPaused) {
				allButtons.interactable = false;
		} else {
			allButtons.interactable = true;
			CheckBuyButtons ();
		}
	}

	private void CheckBuyButtons(){
		float currentMoney = LevelController.instance.startingMoney;
		if (currentMoney < LevelController.instance.SlideCost) {
			allButtons.interactable = false;
		} 
	}
}
