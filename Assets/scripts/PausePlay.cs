using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour {

	private static float timeScale;
	public float TimeScale{
		get{
			return timeScale;
		}
	}
	private Image pausePlayImage;
	public Sprite playImage;
	public Sprite pauseImage;
	public Sprite fastPlayImage;
	public Sprite superFastImage;
	public GameObject pausePlayButton;

	//speed variables used by buttons to change the time scale of the game
	private float pauseSpeed = 0.0f;
	private float regularSpeed = 1.0f;
	private float fastSpeed = 2.0f;
	private float superSpeed = 3.0f;

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
		Time.timeScale = pauseSpeed;
		timeScale = pauseSpeed;
		pausePlayButton.GetComponent<Image>().sprite = playImage;
	}

	public void Pause(GameObject buttonPressed){
		
		if (buttonPressed.name == "Play Pause Button") {
			paused = !paused;
			if (paused) {
				buttonPressed.GetComponent<Image>().sprite = playImage;
				Time.timeScale = pauseSpeed;
				timeScale = pauseSpeed;
			} else {
				buttonPressed.GetComponent<Image>().sprite = pauseImage;
				Time.timeScale = regularSpeed;
				timeScale = regularSpeed;
			}
		} else if (buttonPressed.name == "Fast Forward Button") {
			paused = false;
			pausePlayButton.GetComponent<Image>().sprite = pauseImage;
			Time.timeScale = fastSpeed;
			timeScale = fastSpeed;
		} else if (buttonPressed.name == "Super Fast Forward Button") {
			paused = false;
			pausePlayButton.GetComponent<Image>().sprite = pauseImage;
			Time.timeScale = superSpeed;
			timeScale = superSpeed;
		} else {
			print ("Button pressed doesn't match in PausePlay.cs");
		}
	}
}
