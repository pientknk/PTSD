using UnityEngine;

public class DragObject : MonoBehaviour{

	private Vector3 screenPoint;
	private Vector3 offset;

	private RectTransform levelObjectTransform;

	void Start(){
		levelObjectTransform = LevelController.instance.theLevelObjects.GetComponent<RectTransform> ();
	}

	void OnMouseDrag()
	{
		Vector2 localPointerPosition;
		Vector2 mousePos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		//allCameras[0] is the map camera
		mousePos = ClampToWindow(mousePos);
		Vector2 pos_move = Camera.allCameras[0].ScreenToWorldPoint(mousePos);
			
		transform.position = new Vector2(pos_move.x, pos_move.y);
	}

	Vector2 ClampToWindow (Vector2 position) {
//		Vector3 pos = Camera.allCameras[0].WorldToScreenPoint (position);
//		pos.x = Mathf.Clamp(pos.x);
//		pos.y = Mathf.Clamp(pos.y);
//		transform.position = Camera.allCameras[0].ViewportToWorldPoint(pos);

		Vector3[] canvasCorners = new Vector3[4];
		levelObjectTransform.GetWorldCorners (canvasCorners);

		float clampedX = Mathf.Clamp (position.x, canvasCorners[0].x, canvasCorners[2].x);
		float clampedY = Mathf.Clamp (position.y, canvasCorners[0].y, canvasCorners[2].y);

		Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
		return position;
	}
}
