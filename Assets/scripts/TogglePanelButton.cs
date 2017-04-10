using UnityEngine;
using System.Collections;

public class TogglePanelButton : MonoBehaviour {

	public void TogglePanel (GameObject panel) {
		panel.SetActive (!panel.activeSelf);
	}

	public void TogglePanelActive(GameObject panel){
		panel.SetActive (true);
	}
}

