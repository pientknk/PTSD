using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRotate : MonoBehaviour {

	Vector3 startingPos;
	Vector3 currentPos;
	Vector3 diff;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnMouseDown(){
		startingPos = Input.mousePosition;
	}

	void OnMouseDrag(){
//		currentPos = Input.mousePosition;
//		diff = startingPos - currentPos;
//		diff.Normalize ();
//		Vector3 rotation = transform.rotation.eulerAngles;
//		rotation += (Vector3.back * 10.0f);
//		transform.eulerAngles = rotation;
//		print("Norm: " + diff + " start: " + startingPos + " current: " + currentPos);
	}
}
