using UnityEngine;
using System.Collections;

public class ScoreOrange : MonoBehaviour {

	private float scoreOrange;

	// Use this for initialization
	void Start () {
		scoreOrange = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "boxBlue(Clone)") {
			Destroy (col.gameObject);
			scoreOrange++;
			print ("ORANGE: " + scoreOrange);
		}
	}
}
