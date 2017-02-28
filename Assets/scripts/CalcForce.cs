using UnityEngine;
using System.Collections;

//The goal of this script is to ignore the collision of Orange packages so that the trampoline this will be attached to
//will not bounce orange packages
public class CalcForce : MonoBehaviour {

	private float health = 100;
	public Sprite highHealth;
	public Sprite lowHealth;
	public string color;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = highHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		float speed = gameObject.GetComponent<Rigidbody2D> ().velocity.y;
		if (col.gameObject.name != "truck" + color && speed < -1) {
			health += (speed * 10);
			print ("Speed: " + speed + " Collision: " + col.gameObject.name + " Health: " + health);
			if (health <= 80) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = lowHealth;
			}
		}
	}

}
