using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMute : MonoBehaviour {

	AudioSource music;

	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void toggle (Button buttonPressed) {
		if(music.isPlaying) {
			music.Pause();
		} else {
			music.UnPause();
		}
	}
}
