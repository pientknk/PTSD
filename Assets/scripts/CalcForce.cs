using UnityEngine;
using System.Collections;

//The goal of this script is to ignore the collision of Orange packages so that the trampoline this will be attached to
//will not bounce orange packages
public class CalcForce : MonoBehaviour {

	private float health = 150;
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
		relVelocity = relVelocity / ((Mathf.Sqrt(mass) / 2));
		if (col.gameObject.tag != "truck") {
				if (col.gameObject.tag == "Trampoline") {
					print ("doing " + relVelocity / 5 + " damage");
					health -= (relVelocity / 5);
				} else {
					print ("doing " + relVelocity + " damage");
					health -= relVelocity;
				}
				if (health <= 75) {
					gameObject.GetComponent<SpriteRenderer> ().sprite = lowHealth;
				}
				if (health <= 0) {
					Destroy (gameObject);
				}
		}
	}

	public float GetHealth(){
		return health;
	}

	public float GetMaxHealth(){
		return maxHealth;
	}
}
