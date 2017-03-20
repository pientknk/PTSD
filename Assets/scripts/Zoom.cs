using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	private float yMax;
	Vector3 camPos;

	private float maxOrth;
	private float minOrth = 30.0f;

	private float newOrth;

	// Use this for initialization
	void Start () {
		newOrth = gameObject.GetComponent<Camera> ().orthographicSize;
		maxOrth = gameObject.GetComponent<Camera> ().orthographicSize;

		yMax = maxOrth * transform.position.y;

		camPos.x = transform.position.x;
		camPos.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		camPos = transform.position;

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (newOrth < maxOrth) {
				newOrth += 7.0f;
			}
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (newOrth > minOrth) {
				newOrth -= 7.0f;
			}
		}

		if ((newOrth * camPos.y) > yMax) {
			camPos.y -= 70.0f;
			gameObject.GetComponent<Camera> ().transform.position = camPos;
		}

		gameObject.GetComponent<Camera> ().transform.position = camPos;
		gameObject.GetComponent<Camera> ().orthographicSize = newOrth;
		print ("yMax: " + yMax + ", curr Y: " + camPos.y*newOrth + ", New Orth: " + newOrth + " yCam: " + gameObject.GetComponent<Camera>().transform.position.y);
	}
}
