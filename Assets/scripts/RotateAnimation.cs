using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!PausePlay.Instance.Paused) {
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * -500));
		}
	}
}
