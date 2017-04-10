using UnityEngine;

public class DragObject : MonoBehaviour{

	private Vector3 screenPoint;
	private Vector3 offset;

	//when the user clicke on this object it should update the level controller
	void OnMouseDown()
	{
		LevelController.instance.selectedObject = gameObject;
		screenPoint = Camera.allCameras[0].WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.allCameras[0].ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		transform.SetAsLastSibling ();

	}

	//drags the object anywhere on screen, then it should check with the camera to find if the 
	//dragged object is close to being off screen and move camera in that direction
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.allCameras[0].ScreenToWorldPoint (curScreenPoint) + offset;

		transform.position = curPosition;

	}
}
