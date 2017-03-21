using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateObjectPanelLabel : MonoBehaviour {

	private Text label;
	private string objectSelected;
	public string ObjectSelected{
		get{ return objectSelected; }
		set{ objectSelected = value; }
	}

	// Use this for initialization
	void Start () {
		objectSelected = "None";
		label = GetComponent<Text> ();
		if (label == null) {
			print ("No text component found on object with UpdateObjectPanelLabel.cs attached");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (label != null) {
			objectSelected = ObjectPanelController.Ma.NameOfSelectedObject;
			label.text = "Selected: " + objectSelected;
		}
	}
}
