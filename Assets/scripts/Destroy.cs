using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	private float miss;

	// Use this for initialization
	void Start () {
		miss = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if ((col.gameObject.name == "boxBlue(Clone)") || (col.gameObject.name == "boxOrange(Clone)") || (col.gameObject.name == "boxCircleBlue(Clone)") || (col.gameObject.name == "boxCircleOrange(Clone)")) {
			Destroy (col.gameObject);
			miss++;
		}
	}
}
