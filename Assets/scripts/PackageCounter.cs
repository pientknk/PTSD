using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageCounter : MonoBehaviour {

	private Create creator;
	private int numPackages;
	private Text label;
	// Use this for initialization
	void Awake () {
		creator = GameObject.FindGameObjectWithTag ("spawn").GetComponent<Create> ();
		numPackages = creator.NumObjects;
		label = GetComponent<Text> ();
		label.text = "x" + numPackages;
	}
	
	// Update is called once per frame
	void Update () {
		numPackages = creator.NumObjects;
		label.text = "x" + numPackages;
	}
}
