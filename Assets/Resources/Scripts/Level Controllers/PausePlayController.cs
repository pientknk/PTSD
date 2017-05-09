﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the pause and various play speeds available during the game.
/// </summary>
public class PausePlayController : MonoBehaviour {

	public Sprite pauseImage;

	private Text speedLabel;
	private Sprite playImage;
	public Sprite muteImage;
	public Sprite unmuteImage;
	private bool muted;

	private GameObject pausePlayButton;
	// Use this for initialization
	void Start () {
		// get the label for the current speed so that it can be updated
		speedLabel = transform.GetComponentInChildren<Text> ();
		speedLabel.text = "x" + LevelController.instance.PauseGameSpeed;
		// get the 2nd child which is the play/pause button
		playImage = transform.GetChild (1).GetComponent<Image> ().sprite;
		pausePlayButton = transform.GetChild (1).gameObject;
		//start the game paused
		Time.timeScale = LevelController.instance.PauseGameSpeed;

		muted = false;
	}

	/// <summary>
	/// Pauses or plays the game at the speed determined by which button was pressed.
	/// </summary>
	/// <param name="buttonPressed">Button pressed.</param>
	public void PauseOrPlay(Button buttonPressed){

		if (buttonPressed.name == "Play Pause Button") {
			LevelController.instance.IsPaused = !LevelController.instance.IsPaused;
			if (LevelController.instance.IsPaused) {
				buttonPressed.GetComponent<Image> ().sprite = playImage;
				Time.timeScale = LevelController.instance.PauseGameSpeed;
				speedLabel.text = "x" + Time.timeScale;
			} else {
				buttonPressed.GetComponent<Image> ().sprite = pauseImage;
				Time.timeScale = LevelController.instance.RegularGameSpeed;
				speedLabel.text = "x" + Time.timeScale;
			}
		} else if (buttonPressed.name == "Fast Forward Button") {
			LevelController.instance.IsPaused = false;
			pausePlayButton.GetComponent<Image> ().sprite = pauseImage;
			Time.timeScale = LevelController.instance.FastGameSpeed;
			speedLabel.text = "x" + Time.timeScale;
		} else if (buttonPressed.name == "Mute Music") {
			if(muted == false) {
				print (unmuteImage.ToString());
				buttonPressed.GetComponent<Image> ().sprite = unmuteImage;
				muted = true;
			} else {
				print (muteImage.ToString());
				buttonPressed.GetComponent<Image> ().sprite = muteImage;
				muted = false;
			}
		} else {
			LevelController.instance.IsPaused = false;
			pausePlayButton.GetComponent<Image> ().sprite = pauseImage;
			Time.timeScale = LevelController.instance.SuperGameSpeed;
			speedLabel.text = "x" + Time.timeScale;
		}
		//speedLabel.text = "x" + Time.timeScale;
	}
}
