using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler{

	public string text;
	public GameObject toolTip;

	private bool shouldShow;
	private Vector2 cameraPos;
	private float leftEdge;
	private float rightEdge;
	private float topEdge;
	private float bottomEdge;
	private float leftEdgeBox;
	private float rightEdgeBox;
	private float bottomEdgeBox;
	private float topEdgeBox;
	private Rect tooltipRect;
	private Vector2 tooltipCenter;

	void Start(){
		shouldShow = GameController.tooltip;
		cameraPos = Camera.main.gameObject.transform.position;
		leftEdge = cameraPos.x - (float)Screen.width / 2.0f;
		rightEdge = cameraPos.x + (float)Screen.width / 2.0f;
		topEdge = cameraPos.y + (float)Screen.height / 2.0f;
		bottomEdge = cameraPos.y - (float)Screen.height / 2.0f;
		if (toolTip != null) {
			tooltipRect = toolTip.GetComponent<RectTransform> ().rect;
		} else {
			print ("Tooltip not set for tool tip trigger on: " + gameObject.name);
		}
	}

	public void OnPointerEnter(PointerEventData eventData){
		if (shouldShow) {
			Vector3 pos = eventData.position; // x offset - 267, y offset - 251.8
			Vector3 modPos = new Vector3 (pos.x - 267f, pos.y - 251.8f);
			if (toolTip != null) {
				// if left edge of tooltip is off screen, move right
				if (modPos.x - tooltipRect.xMax < leftEdge) {
					modPos.x = leftEdge + tooltipRect.xMax;
				}
				// if right edge of tooltip is off screen, move left
				if (modPos.x + tooltipRect.xMax > rightEdge) {
					modPos.x = rightEdge - tooltipRect.xMax;
				}
				// if top edge of tooltip is off screen, move down
				if (modPos.y + tooltipRect.yMax > topEdge) {
					modPos.y = topEdge - tooltipRect.yMax;
				}
				// if bottom edge of tooltip is off screen, move up
				if (modPos.y - tooltipRect.yMax < bottomEdge) {
					modPos.y = bottomEdge + tooltipRect.yMax;
				}
			}
			StartHover (modPos);
		}
	}

	public void OnSelect(BaseEventData eventData){
		if (shouldShow) {
			StartHover (transform.position);
		}
	}

	public void OnPointerExit(PointerEventData eventData){
		StopHover ();
	}

	public void OnDeselect(BaseEventData eventData){
		StopHover ();
	}

	private void StartHover(Vector3 position){
		ToolTip.Instance.ShowTooltip (text, position);
	}

	private void StopHover(){
		ToolTip.Instance.HideTooltip ();
	}
}
