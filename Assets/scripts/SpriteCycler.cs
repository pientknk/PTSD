using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCycler : MonoBehaviour {

	public float resetTime = 0.25f;
	public List<Sprite> sprites;

	private int i = 0;
	private float currentTime = 0.0f;

	void Update(){
		currentTime += Time.deltaTime;
		if (currentTime >= resetTime) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [i];
			i++;
			currentTime = 0;
		}

		if (i == sprites.Count) {
			i = 0;
		}
	}
}
