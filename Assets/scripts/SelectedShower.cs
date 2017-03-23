using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// added to canvas to manage the ui image that will pop up around the selected object
public class SelectedShower : MonoBehaviour {

	private static SelectedShower instance;
	public static SelectedShower Instance{
		get{ 
			if (instance == null){
				instance = GameObject.FindObjectOfType<SelectedShower>();
			}
			return SelectedShower.instance; 
		}
	}

	public GameObject selectedShow;

	private GameObject selectedObject;
	public GameObject SelectedObject{
		get{ return selectedObject; }
		set{ selectedObject = value; }
	}
		
	void Start(){
		selectedShow = Instantiate (selectedShow);
		selectedShow.transform.SetParent (transform);
	}

	//use to follow the object when it is dragged
	void Update(){
		if (selectedObject != null) {
			// moves the ui selected shower towards the selected object at a certain rate as set in the final parameter
			selectedShow.transform.position = Vector3.MoveTowards (selectedShow.transform.position, selectedObject.transform.position, 15f);
		}
	}

	// add the ui to the selected object by making the ui the parent of the object
	public void addUI(){
		if (selectedObject != null) {
			selectedShow.SetActive (true);
			selectedShow.transform.position = selectedObject.transform.position;
			selectedShow.transform.localScale = selectedObject.transform.localScale;
		
			Rect selectedObjectRect = SelectedObject.GetComponent<RectTransform> ().rect;
			// add 10% of objects width for padding and to make it feel like its surrounding the object
			float width = selectedObjectRect.width + (selectedObjectRect.width / 10);
			float height = selectedObjectRect.height + (selectedObjectRect.height / 10);
			selectedShow.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height);

			//selectedObject.transform.SetParent(selectedShow.transform);
		}
	}

	// remove ui from last selected object first before adding to new object
	public void removeUI(){
		if (selectedObject != null) {
			selectedShow.SetActive (false);
			selectedObject = null;
		}
	}
}
