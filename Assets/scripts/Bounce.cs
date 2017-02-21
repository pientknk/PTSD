using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.name == "boxBlue(Clone)") {
			print ("COLLIDE");
		} else if(col.gameObject.name == "boxOrange(Clone)") {
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
		}

	}

}
