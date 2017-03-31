using UnityEngine;

public class ShowSelectedObject : MonoBehaviour {

	public GameObject showSelectedIndicator;
	private GameObject selectedObject;
	// Use this for initialization
	void Start () {
		selectedObject = LevelController.instance.selectedObject;
		showSelectedIndicator = Instantiate (showSelectedIndicator);
		showSelectedIndicator.transform.SetParent (LevelController.instance.canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelController.instance.selectedObject != null) {
			//only update ui if the selected object has changed
			if (selectedObject != LevelController.instance.selectedObject) {
				selectedObject = LevelController.instance.selectedObject;
				UpdateUI ();
			}
			gameObject.SetActive (true);
			showSelectedIndicator.transform.position = Vector3.MoveTowards (
				showSelectedIndicator.transform.position, 
				LevelController.instance.selectedObject.transform.position, 15f);
		} else {
			gameObject.SetActive (false);
			selectedObject = LevelController.instance.selectedObject;
		}
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
