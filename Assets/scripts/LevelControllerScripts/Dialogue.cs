using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public Image dialogueImage;
	public Text dialogue;
	public Image moreTextIndicator;
	public List<string> dialogueParts;
	public List<Sprite> spriteParts;

	private Sprite currentSpritePart;
	private int index = 0;
	private float timer = 0.0f;
	private float timeBetweenSwitch = 1.0f;
	// Use this for initialization
	void Start () {
		dialogue.text = dialogueParts [index];
		if (spriteParts [index] != null) {
			dialogueImage.sprite = spriteParts [index];
		}
		CheckForMoreText ();
		LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && index < dialogueParts.Count) {
			index++;
			if (index == dialogueParts.Count) {
				LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = true;
				Destroy (gameObject);
			} else {
				if (spriteParts [index] != null) {
					dialogueImage.sprite = spriteParts [index];
				}
				ShowDialogue (index);
				CheckForMoreText ();
			}
		}
		timer += Time.unscaledDeltaTime;
		if (timer >= timeBetweenSwitch) {
			timer = 0.0f;
			ToggleMoreTextIndicator ();
		}
	}

	private void ShowDialogue(int index){
		dialogue.text = dialogueParts [index];
	}

	private void CheckForMoreText(){
		if (dialogueParts.Count > index + 1) {
			moreTextIndicator.gameObject.SetActive (true);
		} else {
			moreTextIndicator.gameObject.SetActive (false);
		}
	}

	private void ToggleMoreTextIndicator(){
		if (dialogueParts.Count > index + 1) {
			moreTextIndicator.gameObject.SetActive (!moreTextIndicator.gameObject.activeSelf);
		}
	}
}
