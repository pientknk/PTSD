using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCommand : MonoBehaviour {

	void OnMouseOver(){
		if (PausePlay.Instance.Paused) {

			if (Input.GetKeyDown (KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)) {
				Destroy (gameObject);
			}
		}
	}
}
