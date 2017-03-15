using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ShowOrHideSubMenu : MonoBehaviour {

	private bool MenuShowing;
	public Sprite closeMenuSprite;
	private Image originalImage;
	private Sprite originalSprite;

	// Use this for initialization
	void Start () {
		originalImage = GetComponent<Image> ();
		originalSprite = originalImage.sprite;
		MenuShowing = false;
	}

	// action method when button on object is pressed
	// should bring up sub menu for object and change sprite on button
	public void ShowOrHideMenu(){
		MenuShowing = !MenuShowing;
		if (MenuShowing) {
			originalImage.sprite = closeMenuSprite;
		} else {
			originalImage.sprite = originalSprite;
		}
	}
}
