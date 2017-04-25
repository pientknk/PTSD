using UnityEngine;
using System.Collections;

public class TogglePanelButton : MonoBehaviour {

	private Vector3 startPos = new Vector3 ((float)-684.5, (float)260.6, (float)0);

	public void TogglePanel (GameObject panel) {
		if(panel.name == "InventoryPanel") {
			panel.transform.localPosition = startPos;
		}
		panel.SetActive (!panel.activeSelf);
	}

	public void TogglePanelActive(GameObject panel){
		panel.SetActive (true);
	}
}

