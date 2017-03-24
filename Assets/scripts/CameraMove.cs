using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	
	//Will be used for changing the position of the camera
	private float camX;
	private float camY;

	//The original x and y coordinates of the camera
	private float xStart;
	private float yStart;

	//Will be used with orthographicSize to prevent scrolling out of the window
	private float xMax;
	private float yMax;

	private float xDiff;
	private float yDiff;

	private Vector3 anchor;
	private Vector3 fromAnchor;
	private Vector3 newPos;

	private float baseOrth;
	private float newOrth;

	private Rigidbody2D r;

	private RaycastHit2D hit;
	private bool scroll;

	void Start() {
		xStart = transform.position.x;
		yStart = transform.position.y;

		newPos = transform.position;
		baseOrth = gameObject.GetComponent<Camera> ().orthographicSize;

		xMax = (transform.position.x * baseOrth);
		yMax = (transform.position.y * baseOrth);
		scroll = true;
	}

	void Update() {

		hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null) {
			if (hit.collider.tag == "Conveyor" || hit.collider.tag == "Fan" || hit.collider.tag != "Slide" || hit.collider.tag == "Trampoline") {
				scroll = false;
			} else {
				scroll = true;
			}
		} else {
			scroll = true;
		}

		if(scroll == true) {
			camX = transform.position.x;
			camY = transform.position.y;

			if (Input.GetMouseButtonDown (0)) {
				anchor = Input.mousePosition;
			}

			if (Input.GetMouseButton (0)) {
				fromAnchor = Input.mousePosition;
				newOrth = gameObject.GetComponent<Camera> ().orthographicSize;

				//without shrinking the difference the movement is way too fast
				xDiff = (anchor.x - fromAnchor.x) / 50.0f;
				yDiff = (anchor.y - fromAnchor.y) / 50.0f;

				if (((camX + xDiff) * newOrth < xMax) && (((((xStart - camX) * 3.0) + xStart) + xDiff) * newOrth < xMax)) {
					camX += xDiff;
				}

				if ((((camY + yDiff) * newOrth) < yMax) && ((((Mathf.Abs(yStart - camY) * 2.0) + yStart) + yDiff) * Mathf.Abs((baseOrth-newOrth)) < yMax)) {
					camY += yDiff;
				}
				
				newPos.x = camX;
				newPos.y = camY;

				transform.position = newPos;
				print ("New Pos: " + newPos + ", xMax: " + xMax + ", curr X: " + (((((xStart-camX)*2.0) + xStart) + xDiff) * newOrth) + ", yMax: " + yMax + ", curr Y: " + (((Mathf.Abs(yStart - camY) * 2.0) + yStart) + yDiff) * Mathf.Abs((baseOrth-newOrth)) + ", Base Orth: " + baseOrth + ", New Orth: " + gameObject.GetComponent<Camera>().orthographicSize);
			}
		}
	}
}

//		RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, -Vector2.up);
//		if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
//			r = hit.collider.gameObject.GetComponent<Rigidbody2D>();
//			if (r.gameObject.tag == "Conveyor") {
//				print ("Conveyor!");
//			} else {
//				print ("Not Conveyor.");
//			}
//		}