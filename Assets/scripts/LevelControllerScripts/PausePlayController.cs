using UnityEngine;
using UnityEngine.UI;

public class PausePlayController : MonoBehaviour {

	public Sprite pauseImage;

	private Text speedLabel;
	private Sprite playImage;

	private GameObject pausePlayButton;
	// Use this for initialization
	void Start () {
		// get the label for the current speed so that it can be updated
		speedLabel = transform.GetComponentInChildren<Text> ();
		speedLabel.text = "x" + Time.timeScale;
		// get the 2nd child which is the play/pause button
		playImage = transform.GetChild (1).GetComponent<Image> ().sprite;
		pausePlayButton = transform.GetChild (1).gameObject;
		//start the game paused
		Time.timeScale = LevelController.instance.pauseGameSpeed;
	}

	/// <summary>
	/// Pauses or plays the game at the speed determined by which button was pressed.
	/// </summary>
	/// <param name="buttonPressed">Button pressed.</param>
	public void PauseOrPlay(Button buttonPressed){
		if (buttonPressed.name == "Play Pause Button") {
			LevelController.instance.isPaused = !LevelController.instance.isPaused;
			if (LevelController.instance.isPaused) {
				buttonPressed.GetComponent<Image> ().sprite = playImage;
				Time.timeScale = LevelController.instance.pauseGameSpeed;
			} else {
				buttonPressed.GetComponent<Image> ().sprite = pauseImage;
				Time.timeScale = LevelController.instance.regularGameSpeed;
			}
		} else if (buttonPressed.name == "Fast Forward Button") {
			LevelController.instance.isPaused = false;
			pausePlayButton.GetComponent<Image> ().sprite = pauseImage;
			Time.timeScale = LevelController.instance.fastGameSpeed;
		} else {
			LevelController.instance.isPaused = false;
			pausePlayButton.GetComponent<Image> ().sprite = pauseImage;
			Time.timeScale = LevelController.instance.superGameSpeed;
		}
		speedLabel.text = "x" + Time.timeScale;
	}
}
