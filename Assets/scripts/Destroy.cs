using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	private int fails;
	private MoneyTracker mt;

	private DeliveringPackagesCounter dpc;

	// Use this for initialization
	void Start () {
		dpc = GameObject.FindGameObjectWithTag ("successfailure").GetComponent<DeliveringPackagesCounter> ();
		mt = GameObject.FindGameObjectWithTag ("Money").GetComponent<MoneyTracker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		dpc.FailCount += 1;
		Destroy (col.gameObject);
		mt.Money -= 50;
	}
}
