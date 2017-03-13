using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineFilter : MonoBehaviour {

	// initialize to make all objects hit the trampoline
	void Start(){
			gameObject.layer = 0;
	}

	// when hovered over the trampoline while in paused mode, user can update filter
	void OnMouseOver() {
		if (PausePlay.Instance.Paused) {

			// press 'o' key to ignore orange objects
			if (Input.GetKeyDown (KeyCode.O)) {
				gameObject.layer = 8;
			// press 'b' key to ignore blue objects
			} else if (Input.GetKeyDown (KeyCode.B)) {
				gameObject.layer = 9;
			// press 'n' key to not ignore either
			} else if (Input.GetKeyDown (KeyCode.N)) {
				gameObject.layer = 0;
			}
		}
	}
}
