﻿using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "box(Clone)") {
			Destroy (col.gameObject);
			score++;
			print (score);
		}
	}
}