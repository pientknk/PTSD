﻿using UnityEngine;
using System.Collections;

public class ScoreBlue : MonoBehaviour {

	private float scoreBlue;

	// Use this for initialization
	void Start () {
		scoreBlue = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "boxBlue(Clone)") {
			scoreBlue++;
			print ("BLUE: " + scoreBlue);
		} else if(col.gameObject.name == "boxOrange(Clone)") {
				scoreBlue--;
				print ("NOTBLUE!");
		}
		Destroy (col.gameObject);
	}
}