using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;

	private int theScreenWidth;
	private int theScreenHeight;

	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;

	private GameObject theLevelObject;
	private Vector3 levelObjectsRect;


	void Start () {
		GameObject canvas = LevelController.instance.canvas;

		//theScreenWidth = Screen.width;
		//theScreenHeight = Screen.height;
		//theLevelObject = LevelController.instance.theLevelObjects;
		//levelObjectsRect = theLevelObject.GetComponent<RectTransform> ().position;

		//Hard coding in these values will not work on different sized levels.
		//Still working on figuring out how to dynamically find boundaries
		xMin = -710;
		xMax = 485;
		yMin = 235;
		yMax = 438;

		if (canvas != null) {
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform.parent as RectTransform;
		}
	}

	public void OnPointerDown (PointerEventData data) {
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
	}

	public void OnDrag (PointerEventData data) {
		if (this.tag == "inventory") {
			if (panelRectTransform == null)
				return;

			Vector2 pointerPostion = ClampToWindow (data);
			Vector2 localPointerPosition;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
				canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
			)) {
				panelRectTransform.localPosition = localPointerPosition - pointerOffset;
			}
		} else {

			//xMin = levelObjectsRect.x - (theScreenWidth/2) + 600;
			//xMax = levelObjectsRect.x + (theScreenWidth/2) + 600;
			//yMin = levelObjectsRect.y - (theScreenHeight/2) + 70;
			//yMax = levelObjectsRect.y + (theScreenHeight/2) + 70;

				if (panelRectTransform == null)
					return;

				//Vector2 pointerPostion = ClampToWindow (data);
				Vector2 pointerPostion = data.position;

				Vector2 localPointerPosition;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
				     canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
			     )) {
				
				if ((panelRectTransform.localPosition.x > xMin) && (panelRectTransform.localPosition.x < xMax) && (panelRectTransform.localPosition.y < yMax) && (panelRectTransform.localPosition.y > yMin)) {
					panelRectTransform.localPosition = localPointerPosition - pointerOffset;
				}

				if (panelRectTransform.localPosition.x < xMin) {
					panelRectTransform.localPosition = new Vector3 ((xMin + 1), panelRectTransform.localPosition.y);
				}

				if (panelRectTransform.localPosition.x > xMax) {
					panelRectTransform.localPosition = new Vector3 ((xMax - 1), panelRectTransform.localPosition.y);
				}

				if (panelRectTransform.localPosition.y > yMax) {
					panelRectTransform.localPosition = new Vector3 (panelRectTransform.localPosition.x, (yMax - 1));
				}

				if (panelRectTransform.localPosition.y < yMin) {
					panelRectTransform.localPosition = new Vector3 (panelRectTransform.localPosition.x, (yMin + 1));
				}
			}
		}

	}

	Vector2 ClampToWindow (PointerEventData data) {
		Vector2 rawPointerPosition = data.position;

		Vector3[] canvasCorners = new Vector3[4];
		canvasRectTransform.GetWorldCorners (canvasCorners);

		float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
		float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

		Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
		return newPointerPosition;
	}
}