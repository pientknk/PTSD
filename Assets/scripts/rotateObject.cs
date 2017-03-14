using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour{

	public float rotateAngle = 15.0f;

	// allow rotation using arrows while mouse is over object
	void OnMouseOver() {
		if (PausePlay.Instance.Paused) {

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					Vector3 rotation = transform.rotation.eulerAngles;
					rotation += (Vector3.forward * rotateAngle);
					transform.eulerAngles = rotation;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
					Vector3 rotation = transform.rotation.eulerAngles;
					rotation += (Vector3.back * rotateAngle);
					transform.eulerAngles = rotation;
			}
		}
	}
}
