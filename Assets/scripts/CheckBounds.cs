using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBounds : MonoBehaviour {

	private Camera camera;

	private GameObject rightBound;
	private GameObject leftBound;
	private GameObject upperBound;
	private GameObject lowerBound;

	private GameObject lvlObjects;
	private RectTransform lvlRect;
	private Vector3 objPos;

	private bool inBounds;


	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();

		//rightBound = GameObject.Find ("RightBound");
		//leftBound = GameObject.Find ("LeftBound");
		//upperBound = GameObject.Find ("UpperBound");
		//lowerBound = GameObject.Find ("LowerBound");

		rightBound = GameObject.Find ("Kill Zone Right");
		leftBound = GameObject.Find ("Kill Zone Left");
		upperBound = GameObject.Find ("Kill Zone Ceiling");
		lowerBound = GameObject.Find ("Kill Zone Floor");

		lvlObjects = GameObject.Find ("TheLevelObjects");
		lvlRect = lvlObjects.GetComponent<RectTransform>();
		objPos = lvlRect.localPosition;

		inBounds = true;
	}

	// Update is called once per frame
	void Update () {
		Vector3 rightPos = camera.WorldToViewportPoint(rightBound.transform.position);
		Vector3 leftPos = camera.WorldToViewportPoint(leftBound.transform.position);
		Vector3 upperPos = camera.WorldToViewportPoint(upperBound.transform.position);
		Vector3 lowerPos = camera.WorldToViewportPoint(lowerBound.transform.position);

		print ("Right pos: " + rightPos.x + ", Left pos:" + leftPos.x + " Upper Pos: " + upperPos.y + " Lower Pos: " + lowerPos.y  + " In Bounds: " + inBounds);

		objPos = lvlRect.localPosition;

		if (rightPos.x < 0.265F) {
			objPos.x += 12;
			inBounds = false;
		} else {
			inBounds = true;
		}

		if (leftPos.x > -0.15F) {
			objPos.x -= 12;
			inBounds = false;
		} else {
			inBounds = true;
		}

		if (upperPos.y < 0.59F) {
			objPos.y += 12;
			inBounds = false;
		} else {
			inBounds = true;
		}

		if (lowerPos.y > 0.159F) {
			objPos.y -= 12;
			inBounds = false;
		} else {
			inBounds = true;
		}


		lvlRect.localPosition = objPos;

	}
}