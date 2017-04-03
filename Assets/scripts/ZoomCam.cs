using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour {

	private Vector3 originalPos;
	private Vector3 newPos;
	private Vector3 zoomScale;

	// Use this for initialization
	void Start () {

		originalPos.x = gameObject.GetComponent<RectTransform> ().position.x;
		originalPos.y = gameObject.GetComponent<RectTransform> ().position.y;
		originalPos.z = gameObject.GetComponent<RectTransform> ().position.z;

		newPos.x = gameObject.GetComponent<RectTransform> ().position.x;
		newPos.y = gameObject.GetComponent<RectTransform> ().position.y;
		newPos.z = gameObject.GetComponent<RectTransform> ().position.z;

		zoomScale = new Vector3 (1, 1, 1);
	}

	// Update is called once per frame
	void Update () {

		newPos = transform.position;

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if(zoomScale.x > 1 && zoomScale.y > 1) {
				zoomScale.x -= 0.1F;
				zoomScale.y -= 0.1F;

				newPos.x += (originalPos.x - newPos.x) / 5f;
				newPos.y += (originalPos.y - newPos.y) / 5f;
			}			
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) {

			zoomScale.x += 0.1F;
			zoomScale.y += 0.1F;

			//1250 seems to be the required mouse delay to properly zoom in on the mouse position
			newPos.x -= ((Input.mousePosition.x-1250) - newPos.x) / 10f;

			//400 seems to be the Y delay
			newPos.y -= ((Input.mousePosition.y-400) - newPos.y) / 10.0f;
		}

		gameObject.GetComponent<RectTransform> ().localScale = zoomScale;

		if (zoomScale.x == 1) {
			newPos = originalPos;
		}

		gameObject.GetComponent<RectTransform> ().position = newPos;

	}
}

