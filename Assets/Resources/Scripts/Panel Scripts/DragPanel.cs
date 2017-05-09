using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Allows any panel to be drug around on the screen using pointer and drag handlers
/// </summary>
public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;

	void Start () {
		GameObject canvas = LevelController.instance.canvas;

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
			
				if (panelRectTransform == null)
					return;

				Vector2 pointerPostion = ClampToWindow (data);

				Vector2 localPointerPosition;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
				     canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
			     )) {
				
				panelRectTransform.localPosition = localPointerPosition - pointerOffset;
			}
		}

	}

	/// <summary>
	/// Clamps to window so that the panel cannot be drug past the screen with the mouse.
	/// </summary>
	/// <returns>The to window.</returns>
	/// <param name="data">Data.</param>
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