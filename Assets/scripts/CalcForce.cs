using UnityEngine;
using System.Collections;

//The goal of this script is to ignore the collision of Orange packages so that the trampoline this will be attached to
//will not bounce orange packages
public class CalcForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		print (col.relativeVelocity);
		//float velX = col.gameObject.GetComponent<Rigidbody2D> ().velocity.x;
		//float velY = col.gameObject.GetComponent<Rigidbody2D> ().velocity.y;
		//float mass = col.gameObject.GetComponent<Rigidbody2D> ().mass;
		//print ("X: " + (velX*mass) + " Y:" + (velY*mass));
	}

}
