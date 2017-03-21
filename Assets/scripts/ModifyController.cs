using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add to every unsable object prefab such as conveyor
// then when any usable object is selected it can update the modify actions script
// will send information and reference of itself to modify actions
public class ModifyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		updateOPC();
	}

	// update modify action script and make sure the object panel is active
	void OnMouseDown () {
		updateOPC ();
	}

	private void updateOPC(){
		ObjectPanelController.togglePanelActive ();
		ObjectPanelController.Ma.SelectedObject = gameObject;
		ObjectPanelController.Ma.ChangedSelectedObject ();
		ObjectPanelController.Ma.SetUpButtonActions ();
	}
}
