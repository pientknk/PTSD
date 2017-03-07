using UnityEngine;
using System.Collections;

//Was using this script to switch direction of converyor belt. No longer will be used but may be useful reference for
//future scripts
public class Switch : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			gameObject.GetComponent<SurfaceEffector2D>().speed *= -1;
		}
	}
}
