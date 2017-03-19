using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyActions : MonoBehaviour {

	private GameObject selectedObject;
	public GameObject SelectedObject{
		set{ selectedObject = value; }
	}
	private Color originalObjectColor = Color.white;
	private Button[] allButtons;
	// Use this for initialization
	void Start () {
		allButtons = GetComponentsInChildren<Button> ();
		SetUpButtonActions ();
	}

	private void SetUpButtonActions(){
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

	void Update(){
		// if the object selected is not a usable object then don't modify buttons and disable them
		if (selectedObject == null) {
			foreach (Button button in allButtons) {
				button.interactable = false;
			}
		// usable object selected so update buttons so that they will modify this selected object
		} else {
			foreach (Button button in allButtons) {
				//SetUpButtonActions ();
				button.interactable = true;
			}
		}
	}

	private void Sell(GameObject theObject){
		//add to bank then destroy

		Destroy (gameObject);

	}

	private void HitOrange(GameObject theObject){
		theObject.GetComponent<Image>().color = new Color(1.0f, .6f, 0.0f, 1.0f);
		theObject.layer = 9;
	}

	private void HitBlue(GameObject theObject){
		theObject.GetComponent<Image>().color = Color.blue;
		theObject.layer = 8;
	}

	private void HitBoth(GameObject theObject){
		theObject.GetComponent<Image>().color = originalObjectColor;
		theObject.layer = 0;
	}

	private void RotateLeft(GameObject theObject) {
		if (PausePlay.Instance.Paused) {
			Vector3 rotation = theObject.transform.rotation.eulerAngles;
			rotation += (Vector3.forward * 15.0f);
			theObject.transform.eulerAngles = rotation;
		}
	}

	private void RotateRight(GameObject theObject) {
		if (PausePlay.Instance.Paused) {
			Vector3 rotation = theObject.transform.rotation.eulerAngles;
			rotation += (Vector3.back * 15.0f);
			theObject.transform.eulerAngles = rotation;
		}
	}

	private void Expand(GameObject theObject){

	}

	private void Shrink(GameObject theObject){

	}
}
