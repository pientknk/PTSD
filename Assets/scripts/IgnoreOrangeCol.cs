using UnityEngine;
using System.Collections;

//The goal of this script is to ignore the collision of Orange packages so that the trampoline this will be attached to
//will not bounce orange packages
public class IgnoreOrangeCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.name == "boxBlue(Clone)") {
		
		} else if(col.gameObject.name == "boxOrange(Clone)") {
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
		}

	}

}
