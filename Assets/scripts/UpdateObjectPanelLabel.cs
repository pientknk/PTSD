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
	private GetSelectedObject gso;

	// Use this for initialization
	void Start () {
		objectSelected = "None";
		label = GetComponent<Text> ();
		if (label == null) {
			print ("No text component found on object with UpdateObjectPanelLabel.cs attached");
		}
		gso = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<GetSelectedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (label != null) {
			objectSelected = gso.NameObject;
			label.text = "Selected: " + objectSelected;
		}
	}
}
