using UnityEngine;
using System.Collections;

public class ColorOrange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = new Color (244, 167, 66, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
