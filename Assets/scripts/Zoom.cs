using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	private float yMax;

	Vector3 camNewPos;
	Vector3 camStartPos;

	private float maxOrth;
	private float minOrth = 30.0f;

	private float newOrth;

	// Use this for initialization
	void Start () {
		newOrth = gameObject.GetComponent<Camera> ().orthographicSize;
		maxOrth = gameObject.GetComponent<Camera> ().orthographicSize;

		yMax = maxOrth * transform.position.y;

		camStartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		camNewPos = transform.position;
	
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (newOrth < maxOrth) {
				newOrth += 7.0f;
				//this will help so we always zoom out to the origial camera position.
				//dividing by 4 helps smooth the process out
				camNewPos.x = ((camStartPos.x - camNewPos.x) / 4.0f) + camNewPos.x;
				camNewPos.y = ((camStartPos.y - camNewPos.y) / 4.0f) + camNewPos.y;
			}
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (newOrth > minOrth) {
				newOrth -= 7.0f;
				//this will help so that we zoom in where towards where the mouse is pointing.
				//dividing by 4 helps smooth the process out
				camNewPos.x = ((Input.mousePosition.x - camNewPos.x) / 25.0f) + camNewPos.x;
				camNewPos.y = ((Input.mousePosition.y - camNewPos.y) / 25.0f) + camNewPos.y;
				print ("Mouse.x: " + Input.mousePosition.x + ", Mouse.y: " + Input.mousePosition.y + ", Cam.x: " + camNewPos.x + ", Cam.y: " + camNewPos.y);
			}
		}
				
		gameObject.GetComponent<Camera> ().transform.position = camNewPos;
		gameObject.GetComponent<Camera> ().orthographicSize = newOrth;
		//print ("yMax: " + yMax + ", curr Y: " + camPos.y*newOrth + ", New Orth: " + newOrth + " yCam: " + gameObject.GetComponent<Camera>().transform.position.y);
	}
}
