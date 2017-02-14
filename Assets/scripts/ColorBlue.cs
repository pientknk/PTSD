using UnityEngine;
using System.Collections;

public class ColorBlue : MonoBehaviour {


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = new Color ((float)1.0, (float)0.50, (float)0.0, (float)1.0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
