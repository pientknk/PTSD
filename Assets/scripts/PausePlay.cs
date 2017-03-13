using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour {


	public Sprite playImage;
	public Sprite pauseImage;
	private bool paused;

	public bool Paused{
		get{ return paused; }
	}
	private static PausePlay instance;

	public static PausePlay Instance{
		get{ 
			if (instance == null){
				instance = GameObject.FindObjectOfType<PausePlay>();
			}
			return PausePlay.instance; 
		}
	}
	// Use this for initialization
	void Start () {
		paused = true;
		Time.timeScale = 0.0f;
		GetComponent<Image> ().sprite = playImage;
		//print ("Paused");
	}

	public void Pause(){
		paused = !paused;
		if (paused) {
			//print ("Pause");
			Time.timeScale = 0.0f;
		} else {
			//print ("Play");
			Time.timeScale = 1.0f;
		}
		if (GetComponent<Image> ().sprite == pauseImage) {
			GetComponent<Image> ().sprite = playImage;
		} else {
			GetComponent<Image> ().sprite = pauseImage;
		}
	}
}
