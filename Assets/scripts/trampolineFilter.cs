using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trampolineFilter : MonoBehaviour {

	private Image trampolineImage;
	private Color origin;
	// initialize to make all objects hit the trampoline
	void Start(){
		gameObject.layer = 0;
		trampolineImage = GetComponent<Image> ();
		origin = trampolineImage.color;
	}

	// when hovered over the trampoline while in paused mode, user can update filter
	void OnMouseOver() {
		if (PausePlay.Instance.Paused) {
			// press 'o' key to hit only orange objects
			if (Input.GetKeyDown (KeyCode.O)) {
				trampolineImage.color = new Color(1.0f, .6f, 0.0f, 1.0f);
				gameObject.layer = 9;
			// press 'b' key to hit only blue objects
			} else if (Input.GetKeyDown (KeyCode.B)) {
				trampolineImage.color = Color.blue;
				gameObject.layer = 8;
			// press 'n' key to not ignore either
			} else if (Input.GetKeyDown (KeyCode.N)) {
				trampolineImage.color = origin;
				gameObject.layer = 0;
			}
		}
	}
}
