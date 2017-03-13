using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateWind : MonoBehaviour {

	public float windStrength = 100.0f;
	private Rigidbody2D body;

	void OnTriggerEnter(Collider obj){
		//print ("trigger was entered");
		body = obj.GetComponent<Rigidbody2D> ();
		if (body != null) {
			body.AddForce (Vector2.left * windStrength);
		}
	}

	void OnTriggerStay(Collider obj){
		//print("Trigger stay");
		if (body != null) {
			body.AddForce (Vector2.left * windStrength * Time.deltaTime);
		}
	}
}
