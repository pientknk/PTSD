using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour {

	//Zoom Variables
	private Vector3 originalPos;
	private Vector3 newPos;
	private Vector3 zoomScale;

	//Difference variables for movement
	float xDiff;
	float yDiff;

	private Vector3 center;

	void Start () {
		originalPos.x = gameObject.GetComponent<RectTransform> ().position.x;
		originalPos.y = gameObject.GetComponent<RectTransform> ().position.y;
		originalPos.z = gameObject.GetComponent<RectTransform> ().position.z;

		center.x = (Screen.width / 2);
		center.y = (Screen.height / 2);

		zoomScale = new Vector3 (1, 1, 1);
	}

	void Update () {

		newPos = transform.position;
		center.x = (Screen.width / 2);
		center.y = (Screen.height / 2);

		//Zoom
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (zoomScale.x > 1 && zoomScale.y > 1) {
				zoomScale.x -= 0.1F;
				zoomScale.y -= 0.1F;

				newPos.x += (originalPos.x - newPos.x) / (zoomScale.y * 5f);
				newPos.y += (originalPos.y - newPos.y) / (zoomScale.y * 5f);
			}			
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) {

			zoomScale.x += 0.1F;
			zoomScale.y += 0.1F;

			//1250 seems to be the required mouse delay to properly zoom in on the mouse position
			newPos.x -= ((Input.mousePosition.x - 1250) - newPos.x) / (zoomScale.x * 10f);

			//400 seems to be the Y delay
			newPos.y -= ((Input.mousePosition.y - 400) - newPos.y) / (zoomScale.y * 10.0f);
		}

		gameObject.GetComponent<RectTransform> ().localScale = zoomScale;

		if (zoomScale.x <= 1) {
			newPos = originalPos;
			zoomScale.x = 1;
			zoomScale.y = 1;
		}

		//Mouse Push Movement
		if (zoomScale.x > 1) {
			
			if (((center.x - (300 / zoomScale.x)) > Input.mousePosition.x) || (center.x + (300 / zoomScale.x)) < Input.mousePosition.x){
				xDiff = (Input.mousePosition.x - center.x) / 60.0f;
				newPos.x -= xDiff;
			}

			if (((center.y + (250 / zoomScale.y)) < Input.mousePosition.y) || ((center.y - (250 / zoomScale.y)) > Input.mousePosition.y)) {
				yDiff = (Input.mousePosition.y - center.y) / 40.0f;
				newPos.y -= yDiff;
			}

		}

		gameObject.GetComponent<RectTransform> ().position = newPos;

	}

}