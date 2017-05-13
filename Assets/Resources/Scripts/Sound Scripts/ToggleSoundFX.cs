using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// Toggle SFX during gameplay
/// </summary>
public class ToggleSoundFX : MonoBehaviour {

	bool mute;
	GameObject explode;
	GameObject shatter;
	GameObject shatter2;

	void Start() {

		mute = !GameController.sounds;
		explode = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Packages/Explosion.prefab", typeof(GameObject)) as GameObject; 
		shatter = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Packages/Wrecked Orange Package.prefab", typeof(GameObject)) as GameObject;
		shatter2 = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Packages/Wrecked Blue Package.prefab", typeof(GameObject)) as GameObject;
		explode.GetComponent<AudioSource>().playOnAwake = mute;
		shatter.GetComponent<AudioSource>().playOnAwake = mute;
		shatter2.GetComponent<AudioSource>().playOnAwake = mute;
	}

	public void toggle (Button buttonPressed) {
		if (mute == false) {
			explode.GetComponent<AudioSource>().playOnAwake = mute;
			shatter.GetComponent<AudioSource>().playOnAwake = mute;
			shatter2.GetComponent<AudioSource>().playOnAwake = mute;
			mute = true;
		} else {
			explode.GetComponent<AudioSource>().playOnAwake = mute;
			shatter.GetComponent<AudioSource>().playOnAwake = mute;
			shatter2.GetComponent<AudioSource>().playOnAwake = mute;
			mute = false;
		}
	}
}
