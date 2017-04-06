using UnityEngine;
using UnityEngine.UI;

public class ShowSelectedObject : MonoBehaviour {

	public GameObject showSelectedIndicator;
	private GameObject selectedObject;
	// Use this for initialization
	void Start () {
		selectedObject = LevelController.instance.selectedObject;
		showSelectedIndicator = Instantiate (showSelectedIndicator);
		showSelectedIndicator.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.6f);
		GameObject levelCanvas = gameObject;
		showSelectedIndicator.transform.SetParent (levelCanvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.isPaused) {
			showSelectedIndicator.SetActive (false);
		} else {
			if (LevelController.instance.selectedObject != null) {
				//only update ui if the selected object has changed
				if (selectedObject != LevelController.instance.selectedObject) {
					selectedObject = LevelController.instance.selectedObject;
					UpdateUI ();
				}
				showSelectedIndicator.SetActive (true);
				gameObject.SetActive (true);
				showSelectedIndicator.transform.position = Vector3.MoveTowards (
					showSelectedIndicator.transform.position, 
					LevelController.instance.selectedObject.transform.position, 15f);
			} 
			//if selected object is null, hide the indicator
			else {
				showSelectedIndicator.SetActive (false);
				selectedObject = LevelController.instance.selectedObject;
			}
		}
	}

	/// <summary>
	/// Updates the selected object indicator, should be called anytime selected object changes.
	/// </summary>
	public void UpdateUI(){
		showSelectedIndicator.SetActive (true);
		showSelectedIndicator.transform.position = LevelController.instance.selectedObject.transform.position;
		showSelectedIndicator.transform.localScale = LevelController.instance.selectedObject.transform.localScale;

		Rect selectedObjectRect = LevelController.instance.selectedObject.GetComponent<RectTransform> ().rect;
		// add 15% of the selected objects width and height to surround it with the indicator
		float width = selectedObjectRect.width + (selectedObjectRect.width * .50f);
		float height = selectedObjectRect.height + (selectedObjectRect.height * .50f);
		if (height < width) {
			height = width;
		} else {
			width = height;
		}
		showSelectedIndicator.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height);
	}
}
