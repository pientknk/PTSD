using System.Collections.Generic;
using UnityEngine;

public class MagnetAttraction : MonoBehaviour {

	private float force = 8500;
	private List<Collider2D> allColliders;

	void Start(){
		allColliders = new List<Collider2D> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		allColliders.Add (col);
	}

	void OnTriggerStay2D(Collider2D col){
		if (col == null) {
			allColliders.Remove (col);
		}
		foreach (Collider2D collider in allColliders) {
			if (collider != null) {
				Vector3 forceDirection = transform.position - collider.transform.position;
				print ("applying force: " + forceDirection.normalized * force * Time.deltaTime + " to object: " + collider.name);
				collider.attachedRigidbody.AddForce (forceDirection.normalized * force * Time.deltaTime, ForceMode2D.Impulse);
				//Vector2 newVelocity = collider.attachedRigidbody.velocity - 0.5f*Time.deltaTime* new Vector2(forceDirection.x, forceDirection.y);
				//collider.attachedRigidbody.velocity = newVelocity;
			} 
		}
	}

	void OnTriggerExit2D(Collider2D col){
		allColliders.Remove (col);
	}
}
