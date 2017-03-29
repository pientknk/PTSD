using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSelectedObject : MonoBehaviour {

	public GameObject showSelectedIndicator;
	// Use this for initialization
	void Start () {
		showSelectedIndicator = Instantiate (showSelectedIndicator);
		showSelectedIndicator.transform.SetParent (LevelController.instance.canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		showSelectedIndicator.transform.position = Vector3.MoveTowards (
			showSelectedIndicator.transform.position, 
			LevelController.instance.selectedObject.transform.position, 15f);
		
	}

	/// <summary>
	/// Updates the selected object indicator, should be called anytime selected object changes.
	/// </summary>
	public void UpdateUI(){
		showSelectedIndicator.transform.position = LevelController.instance.selectedObject.transform.position;
		showSelectedIndicator.transform.localScale = LevelController.instance.selectedObject.transform.localScale;

		Rect selectedObjectRect = LevelController.instance.selectedObject.GetComponent<RectTransform> ().rect;
		// add 15% of the selected objects width and height to surround it with the indicator
		float width = selectedObjectRect.width + (selectedObjectRect.width * .15f);
		float height = selectedObjectRect.height + (selectedObjectRect.height * .15f);
		showSelectedIndicator.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height);
	}
}
