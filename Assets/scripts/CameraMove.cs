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

	void Start() {
		xStart = transform.position.x;
		yStart = transform.position.y;

		newPos = transform.position;
		baseOrth = gameObject.GetComponent<Camera> ().orthographicSize;

		xMax = (transform.position.x * baseOrth);
		yMax = (transform.position.y * baseOrth);
	}

	void Update() {

		camX = transform.position.x;
		camY = transform.position.y;

		if(Input.GetMouseButtonDown(0)) {
			anchor = Input.mousePosition;
		}

		if(Input.GetMouseButton(0)) {
			fromAnchor = Input.mousePosition;
			newOrth = gameObject.GetComponent<Camera> ().orthographicSize;

			//without shrinking the difference the movement is way too fast
			xDiff = (anchor.x - fromAnchor.x)/40.0f;
			yDiff = (anchor.y - fromAnchor.y)/40.0f;

			if(((camX + xDiff) * newOrth < xMax) && ((((xStart-camX) + xStart) + xDiff) * newOrth < xMax)) {
				camX += xDiff;
			}

			if ((((camY + yDiff) * newOrth) < yMax) && ((((yStart-camY) + yStart) + yDiff) * newOrth < yMax)) {
				camY += yDiff;
			}
				
			newPos.x = camX;
			newPos.y = camY;

			transform.position = newPos;
			//print ("New Pos: " + newPos + ", yMax: " + yMax + ", curr Y: " + camY*newOrth + ", Base Orth: " + baseOrth + ", New Orth: " + gameObject.GetComponent<Camera>().orthographicSize);
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