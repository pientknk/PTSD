using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyActions : MonoBehaviour {

	private string nameOfSelectedObject;
	public string NameOfSelectedObject{
		set{ nameOfSelectedObject = value; }
		get{ return nameOfSelectedObject; }
	}
	private GameObject selectedObject;
	public GameObject SelectedObject{
		set{ selectedObject = value; }
	}
	private Color originalObjectColor = Color.white;
	private Button[] allButtons;
	// Use this for initialization
	void Start () {
		allButtons = GetComponentsInChildren<Button> ();
		nameOfSelectedObject = "None";
		UpdateButtons ();
	}

	// should update the name of selected object when called
	public void ChangedSelectedObject(){
		switch (selectedObject.tag) {
		case "Conveyor":
			nameOfSelectedObject = "Conveyor";
			break;
		case "Fan":
			nameOfSelectedObject = "Fan";
			break;
		case "Slide":
			nameOfSelectedObject = "Slide";
			break;
		case "Trampoline":
			nameOfSelectedObject = "Trampoline";
			break;
		default:
			nameOfSelectedObject = "None";
			break;
		}
		UpdateButtons ();
	}

	public void SetUpButtonActions(){
		foreach (Button button in allButtons) {
			button.onClick.RemoveAllListeners();
		}
		allButtons[0].onClick.AddListener (delegate {
			Sell(selectedObject);
		});
		allButtons[1].onClick.AddListener (delegate {
			HitOrange(selectedObject);
		});
		allButtons[2].onClick.AddListener (delegate {
			HitBlue(selectedObject);
		});
		allButtons[3].onClick.AddListener (delegate {
			HitBoth(selectedObject);
		});
		allButtons[4].onClick.AddListener (delegate {
			RotateLeft(selectedObject);
		});
		allButtons[5].onClick.AddListener (delegate {
			RotateRight(selectedObject);
		});
		allButtons[6].onClick.AddListener (delegate {
			Expand(selectedObject);
		});
		allButtons[7].onClick.AddListener (delegate {
			Shrink(selectedObject);
		});
	}

	void UpdateButtons(){
		// if the object selected is not a usable object then don't modify buttons and disable them
		if (selectedObject == null) {
				//print ("setting buttons not interactable");
				foreach (Button button in allButtons) {
					button.interactable = false;
				}
		// usable object selected so update buttons so that they will modify this selected object
		} else {
				//print ("setting buttons interactable");
				foreach (Button button in allButtons) {
					button.interactable = true;
				}
		}
	}

	private void Sell(GameObject theObject){
		//add to bank then destroy then update panel label
		if (PausePlay.Instance.Paused) {
			Destroy (theObject);
			nameOfSelectedObject = "None";
			selectedObject = null;
			UpdateButtons ();

			// update selector to be gone
			SelectedShower.Instance.removeUI ();
			SelectedShower.Instance.SelectedObject = null;
		}
	}


	private void HitOrange(GameObject theObject){
		//print ("Orange Filter On");
		if (PausePlay.Instance.Paused) {
			theObject.GetComponent<Image> ().color = new Color (1.0f, .6f, 0.0f, 1.0f);
			theObject.layer = 9;
		}
	}

	private void HitBlue(GameObject theObject){
		//print ("blue Filter On");
		if (PausePlay.Instance.Paused) {
			theObject.GetComponent<Image> ().color = Color.blue;
			theObject.layer = 8;
		}
	}

	private void HitBoth(GameObject theObject){
		//print ("no Filter On");
		if (PausePlay.Instance.Paused) {
			theObject.GetComponent<Image> ().color = originalObjectColor;
			theObject.layer = 0;
		}
	}

	private void RotateLeft(GameObject theObject) {
		//print ("rotate left");
		if (PausePlay.Instance.Paused) {
			Vector3 rotation = theObject.transform.rotation.eulerAngles;
			rotation += (Vector3.forward * 15.0f);
			theObject.transform.eulerAngles = rotation;
		}
	}

	private void RotateRight(GameObject theObject) {
		//print ("rotate right");
		if (PausePlay.Instance.Paused) {
			Vector3 rotation = theObject.transform.rotation.eulerAngles;
			rotation += (Vector3.back * 15.0f);
			theObject.transform.eulerAngles = rotation;
		}
	}

	private void Expand(GameObject theObject){
		//print ("Expand");
		if (PausePlay.Instance.Paused) {

		}
	}

	private void Shrink(GameObject theObject){
		//print ("shrink");
		if (PausePlay.Instance.Paused) {

		}
	}
}
