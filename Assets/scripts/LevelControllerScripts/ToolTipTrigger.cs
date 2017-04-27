using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler{

	public string text;

	public void OnPointerEnter(PointerEventData eventData){
////		print ("Pos: " + eventData.position);
//		print ("Canvas Pos: " + LevelController.instance.canvas.gameObject.transform.position);
////		print ("Diff: " + (eventData.position.x - LevelController.instance.canvas.gameObject.transform.position.x) + " " + 
////			(eventData.position.y - LevelController.instance.canvas.gameObject.transform.position.y));
		print(Input.mousePosition);
		StartHover (Input.mousePosition);
	}

	public void OnSelect(BaseEventData eventData){
		StartHover (transform.position);
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
