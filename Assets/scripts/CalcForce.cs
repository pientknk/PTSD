using UnityEngine;
using System.Collections;

//The goal of this script is to ignore the collision of Orange packages so that the trampoline this will be attached to
//will not bounce orange packages
public class CalcForce : MonoBehaviour {

	private float health = 100;
	private float maxHealth = 100;
	public Sprite highHealth;
	public Sprite lowHealth;
	private string name;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = highHealth;
		//FloatingTextController.Initialize ();
		name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) {
		
		float relVelocity = (float)(Mathf.Abs(col.relativeVelocity.y) + Mathf.Abs(col.relativeVelocity.x));
		float mass = gameObject.GetComponent<Rigidbody2D> ().mass;
		//relVelocity = relVelocity / ((Mathf.Sqrt(mass) / 2));
		if (name == "Box Blue(Clone)" || name == "Box Orange(Clone)") {
			relVelocity = (mass) / (Mathf.Sqrt (relVelocity));
		} else {
			relVelocity = (mass * 1.5f) / (Mathf.Sqrt(relVelocity));
		}

		if (col.gameObject.tag == "Trampoline") {
			//print ("doing " + relVelocity / 8 + " damage");
			health -= (relVelocity / 8);
		} else if (col.gameObject.tag == "Conveyor") {
			//print ("doing " + relVelocity + " damage");
			health -= (relVelocity / 3);
		} else if (col.gameObject.tag == "Slide") {
			//print ("doing " + relVelocity / 2 + " damage");
			health -= (relVelocity / 2);
		}

		if (health <= 50) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = lowHealth;
		}
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	public float GetHealth(){
		return health;
	}

	public float GetMaxHealth(){
		return maxHealth;
	}
}
