﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : MonoBehaviour {

	private float regularHealth = 100;
	private float currentHealth;
	//private float weakHealth = 25;
	//private float strongHealth = 150;

	public GameObject explosion;
	//private string objectName;

	private Transform damageIndicator;
	// Use this for initialization
	void Start () {
		currentHealth = regularHealth;
		//initialize the floating damage object for this package
		FloatingTextController.Initialize ();
		//get the damage indicator so that it can be updated after collisions
		damageIndicator = gameObject.transform.GetComponentInParent<Transform>().GetChild(0);
		//objectName = gameObject.name;
	}

	/// <summary>
	/// Called for every event in which this object's collider hits another collider.
	/// It calculates the damage this package should take.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "scaffold") {
			Destroy (gameObject);
		} else {
			// calcuates the force of impact on the package based on its velocity
			float relVelocity = (float)(Mathf.Abs (col.relativeVelocity.y) + Mathf.Abs (col.relativeVelocity.x));
			float mass = gameObject.GetComponent<Rigidbody2D> ().mass;
			relVelocity = (mass) / (Mathf.Sqrt (relVelocity));

			// reduced damage taken from these objects
			if (col.gameObject.tag == "Trampoline") {
				TakeDamage (relVelocity / 5.5f);
			} else if (col.gameObject.tag == "Conveyor") {
				TakeDamage (relVelocity / 2.5f);
			} else if (col.gameObject.tag == "Slide") {
				TakeDamage (relVelocity / 1.5f);
			} else {
				TakeDamage (relVelocity);
			}
		}
		//update the damage indicator
		Vector3 startingScale = damageIndicator.transform.localScale;
		startingScale *= (currentHealth / regularHealth);
		damageIndicator.transform.localScale = startingScale;

		// once the object has no health it should be destroyed, an explosion occurs, and money is reduced
		if (currentHealth <= 0) {
			Vector2 currentLocation = gameObject.transform.position;
			explosion = Instantiate (explosion);
			explosion.transform.position = currentLocation;
			Destroy (gameObject);
			AnimatorClipInfo[] clipInfo = explosion.GetComponentInChildren<Animator> ().GetCurrentAnimatorClipInfo (0);
			Destroy (explosion, clipInfo [0].clip.length);

			LevelController.instance.currentMoney -= 50;
		}
	}

	/// <summary>
	/// Reduces the health of this package by the specified amount.
	/// </summary>
	/// <param name="amount">Amount.</param>
	private void TakeDamage(float amount){
		FloatingTextController.CreateFloatingText (amount.ToString("F1"), transform.position);
		currentHealth -= amount;
	}
}