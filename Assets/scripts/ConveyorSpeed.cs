using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpeed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Animator>().speed = gameObject.GetComponent<SurfaceEffector2D>().speed/10;
	}
}
