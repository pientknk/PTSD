using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundFX : MonoBehaviour {

	AudioSource music;

	void Start() {
		music = gameObject.GetComponent<AudioSource> ();
	}

	public void toggle (Button buttonPressed) {
		if (music.playOnAwake == false) {
			print ("Turned off");
			music.playOnAwake = true;
		} else {
			print ("Turned on");
			music.playOnAwake = false;
		}
	}
}
