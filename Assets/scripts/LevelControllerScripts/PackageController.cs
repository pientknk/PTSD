using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageController : MonoBehaviour {

	private float regularHealth;
	/// <summary>
	/// Gets the original health of this package
	/// </summary>
	/// <value>The value of regular health.</value>
	public float RegularHealth{
		get{ return regularHealth; }
	}
	private float currentHealth;
	/// <summary>
	/// Gets the current health of this package.
	/// </summary>
	/// <value>The current health.</value>
	public float CurrentHealth{
		get{ return currentHealth; }
	}

	public GameObject explosion;
	//private string objectName;

	public Image healthBar;

	private float relVelocity;
	private float timeBetweenDamage = 0.3f;
	private float timeSinceLastDamage = 0.0f;
	private bool tookDamage = false;
	// Use this for initialization
	void Start () {
		regularHealth = LevelController.instance.packageWorth;
		currentHealth = regularHealth;
		//initialize the floating damage object for this package
		FloatingTextController.Initialize ();
	}

	void Update(){
		if (tookDamage) {
			timeSinceLastDamage += Time.deltaTime;
		}
		if (timeSinceLastDamage >= timeBetweenDamage) {
			tookDamage = false;
			timeSinceLastDamage = 0.0f;
		}
	}

	/// <summary>
	/// Called for every event in which this object's collider hits another collider.
	/// It calculates the damage this package should take.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "scaffold") {
			TakeDamage (currentHealth);
		} else { 
			if (!tookDamage) {
				Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();

				// calcuates the force of impact on the package based on its velocity
				relVelocity = (float)(Mathf.Abs (col.relativeVelocity.y) + Mathf.Abs (col.relativeVelocity.x));
				//Vector2 currentVel = col.relativeVelocity.normalized;
				//print (col.relativeVelocity.x + " " + col.relativeVelocity.y + " " + currentVel.x + " " + currentVel.y);


				float mass = rb.mass;
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
				tookDamage = true;
			}
		}


		// once the object has no health it should be destroyed, an explosion occurs, and money is reduced
		if (currentHealth <= 0) {
			Vector2 currentLocation = gameObject.transform.position;
			explosion = Instantiate (explosion);
			explosion.transform.SetParent (LevelController.instance.theLevelObjects.transform);
			explosion.transform.position = currentLocation;
			if (explosion.gameObject.tag == "Explosion") {
				AnimatorClipInfo[] clipInfo = explosion.GetComponentInChildren<Animator> ().GetCurrentAnimatorClipInfo (0);
				Destroy (explosion, clipInfo [0].clip.length);
			} else {
				foreach (Rigidbody2D body in explosion.GetComponentsInChildren<Rigidbody2D>()) {
					body.velocity = GetComponent<Rigidbody2D> ().velocity;
				}
				Destroy (explosion, 12.0f);
			}
			LevelController.instance.NumPackagesLeft--;
			Destroy (gameObject);
			LevelController.instance.FailurePackages++;
			LevelController.instance.CurrentMoney -= 50;
			checkPackageDestructionCount ();
		}
	}

	/// <summary>
	/// Reduces the health of this package by the specified amount.
	/// </summary>
	/// <param name="amount">Amount.</param>
	private void TakeDamage(float amount){
		if (healthBar != null) {
			healthBar.fillAmount = currentHealth / regularHealth; 
		} else {
			print ("Health bar image not set in packagecontroller, you must set it on each package in the inspector.");
		}
		FloatingTextController.CreateFloatingText (amount.ToString("F1"), transform.position);
		currentHealth -= amount;
	}

	private void checkPackageDestructionCount(){
		if (LevelController.instance.NumPackagesLeft == 0) {
			LevelController.instance.summaryCanvas.SetActive (true);
			Time.timeScale = LevelController.instance.PauseGameSpeed;
			LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
		}
	}

}
