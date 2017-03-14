﻿using UnityEngine;
using System.Collections;

//The goal of this script is to ignore the collision of Orange packages so that the trampoline this will be attached to
//will not bounce orange packages
public class CalcForce : MonoBehaviour {

	private float health = 100;
	private float maxHealth = 100;
	public Sprite highHealth;
	public Sprite lowHealth;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = highHealth;
		//FloatingTextController.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		
		float relVelocity = (float)(Mathf.Abs(col.relativeVelocity.y) + Mathf.Abs(col.relativeVelocity.x));
		float mass = gameObject.GetComponent<Rigidbody2D> ().mass;
		//print (gameObject.name + " hitting with force of: " + relVelocity);
		relVelocity = relVelocity / ((Mathf.Sqrt(mass) / 2));
		//print (gameObject.name + " hitting with CALCULATED force of: " + relVelocity);
		if (col.gameObject.tag != "truck") {
			//int vel = (int)relVelocity;
			//FloatingTextController.CreateFloatingText (vel.ToString(), transform);
			if (col.gameObject.tag == "Trampoline") {
				health -= (relVelocity / 5);
			} else {
				health -= relVelocity;
			}

			//print ("Speed: " + speed + " Collision: " + col.gameObject.name + " Health: " + health);
			if (health <= 70) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = lowHealth;
			}
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
		print (gameObject.name + " " + relVelocity + " health is: " + health);
		//print (gameObject.name + "'s health is: " + health);
	}

	public float GetHealth(){
		return health;
	}

	public float GetMaxHealth(){
		return maxHealth;
	}
}
