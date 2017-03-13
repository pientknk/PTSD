using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class Destroy : MonoBehaviour {

	private float miss;
	private TheBank bank;

	// Use this for initialization
	void Start () {
		miss = 0;
		bank = GetComponent<TheBank> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
			Destroy (col.gameObject);
			bank.subtractMoney (50);
			miss++;
	}
}
