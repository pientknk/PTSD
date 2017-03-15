using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour {


	private Image pausePlayImage;
	public Sprite playImage;
	public Sprite pauseImage;
	public Sprite fastPlayImage;
	public Sprite superFastImage;
	public GameObject pausePlayButton;
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
		pausePlayButton.GetComponent<Image>().sprite = playImage;
	}

	public void Pause(GameObject buttonPressed){
		
		if (buttonPressed.name == "Play Pause Button") {
			paused = !paused;
			if (paused) {
				buttonPressed.GetComponent<Image>().sprite = playImage;
				Time.timeScale = 0.0f;
			} else {
				buttonPressed.GetComponent<Image>().sprite = pauseImage;
				Time.timeScale = 1.0f;
			}
		} else if (buttonPressed.name == "Fast Forward Button") {
			paused = false;
			Time.timeScale = 1.75f;
		} else if (buttonPressed.name == "Super Fast Forward Button") {
			paused = false;
			Time.timeScale = 2.5f;
		} else {
			print ("Button pressed doesn't match in PausePlay.cs");
		}
	}
}
