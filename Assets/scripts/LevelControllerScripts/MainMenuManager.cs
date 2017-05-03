using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Button newgameButton;
	public Button continueButton;

	void Start () {
		if (PlayerPrefs.HasKey ("Level 1 stars")) {
			int stars = PlayerPrefs.GetInt ("Level 1 stars");
			if (stars >= 1) {
				continueButton.interactable = true;
			} else {
				continueButton.interactable = false;
			}
		} else {
			continueButton.interactable = false;
		}
		if (PlayerPrefs.HasKey ("tutorial")) {
			string tutorialDone = PlayerPrefs.GetString ("tutorial");
			print (tutorialDone);
			if (tutorialDone == "yes") {
				newgameButton.interactable = true;
			} else {
				newgameButton.interactable = false;
				continueButton.interactable = false;
			}
		} else {
			continueButton.interactable = false;
			newgameButton.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
