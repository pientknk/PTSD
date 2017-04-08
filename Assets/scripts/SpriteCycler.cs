using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCycler : MonoBehaviour {

	public float resetTime = 0.5f;
	public List<Sprite> sprites;

	private int i = 0;
	private Sprite originalSprite;
	// Use this for initialization
	void Awake(){
		originalSprite = gameObject.GetComponent<Sprite> ();
		StartCoroutine ("ChangeSprites");
		print ("Starting coroutine");
	}
	
	private IEnumerator ChangeSprites(){
		while (true) {
			print ("in loop");
			if (!LevelController.instance.IsPaused) {
					print ("Changing sprite");
					originalSprite = sprites [i];
					i++;
					yield return new WaitForSeconds (resetTime);
			}
		}
	}
}
