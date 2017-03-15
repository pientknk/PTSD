using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class Destroy : MonoBehaviour {

	private int fails;
	private TheBank bank;

	private DeliveringPackagesCounter dpc;

	// Use this for initialization
	void Start () {
		dpc = GameObject.FindGameObjectWithTag ("successfailure").GetComponent<DeliveringPackagesCounter> ();
		bank = GetComponent<TheBank> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		fails = dpc.FailCount;
		fails++;
		dpc.FailCount = fails;
		Destroy (col.gameObject);
		bank.subtractMoney (50);
	}
}
