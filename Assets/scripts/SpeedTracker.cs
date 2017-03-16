using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTracker : MonoBehaviour {

	private PausePlay pp;
	private Text label;
	// Use this for initialization
	void Start () {
		pp = GetComponentInParent<PausePlay> ();
		label = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = ("x" + pp.TimeScale.ToString ("F1"));
	}
}
