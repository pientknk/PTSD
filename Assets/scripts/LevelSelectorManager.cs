using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour {

	[System.Serializable]
	public class Level{
		public string levelText;
		public int unlocked;
		public bool isInteractable;
	}

	public List<Level> levelList;
	public GameObject button;
	public Transform spacer;

	// Use this for initialization
	void Start () {
		FillList ();
	}

	void FillList(){
		foreach (var level in levelList) {
			GameObject newButton = Instantiate (button) as GameObject;
			newButton.transform.SetParent (spacer, false);
			LevelSelector levelSelect = newButton.GetComponent<LevelSelector> ();
			levelSelect.levelText.text = level.levelText;

			if (PlayerPrefs.GetInt (levelSelect.levelText.text) == 1) {
				level.unlocked = 1;
				level.isInteractable = true;
			}

			levelSelect.GetComponent<Button> ().onClick.AddListener (() => LoadLevel (levelSelect.levelText.text));

			if(PlayerPrefs.HasKey(levelSelect.levelText.text + " stars")){
				int stars = PlayerPrefs.GetInt(levelSelect.levelText.text + " stars");
				switch (stars) {
				case 1:
					levelSelect.star1.transform.GetChild (1).gameObject.SetActive (true);
					break;
				case 2:
					levelSelect.star1.transform.GetChild (1).gameObject.SetActive (true);
					levelSelect.star2.transform.GetChild (1).gameObject.SetActive (true);
					break;
				case 3:
					levelSelect.star1.transform.GetChild (1).gameObject.SetActive (true);
					levelSelect.star2.transform.GetChild (1).gameObject.SetActive (true);
					levelSelect.star3.transform.GetChild (1).gameObject.SetActive (true);
					break;
				default:
					break;
				}
			}

			levelSelect.unlocked = level.unlocked;
			levelSelect.GetComponent<Button> ().interactable = level.isInteractable;

		}
		SaveAll ();
	}

	void SaveAll(){
		if (!PlayerPrefs.HasKey ("Level 1")) {
			GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
			foreach (GameObject button in allButtons) {
				LevelSelector levelSelect = button.GetComponent<LevelSelector> ();
				PlayerPrefs.SetInt (levelSelect.levelText.text, levelSelect.unlocked);
			}
		}
	}

	void DeleteAll(){
		PlayerPrefs.DeleteAll ();
	}

	void LoadLevel(string value){
		SceneManager.LoadScene(value);
	}

	// to unlock a level, add this script somewhere in each level and set public variables from another script:
//	public int stars;
//	public int levelToUnlock;
//
//	public void unLockNextLevel(){
//		PlayerPrefs.SetInt ("Level " + levelToUnlock.ToString (), 1);
		//set scores key so that way the stars can be activated accordingly
//		PlayerPrefs.SetInt("Level " + (levelToUnlock - 1).ToString() + " stars", stars);
//	}

}
