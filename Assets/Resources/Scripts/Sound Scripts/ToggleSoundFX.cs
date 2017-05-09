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
		mute = false;
		explode = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Packages/Explosion.prefab", typeof(GameObject)) as GameObject; 
		shatter = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Packages/Wrecked Orange Package.prefab", typeof(GameObject)) as GameObject;
		shatter2 = AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/Packages/Wrecked Blue Package.prefab", typeof(GameObject)) as GameObject;
	}

	public void toggle (Button buttonPressed) {
		if (mute == false) {
			explode.GetComponent<AudioSource>().playOnAwake = false;
			shatter.GetComponent<AudioSource>().playOnAwake = false;
			shatter2.GetComponent<AudioSource>().playOnAwake = false;
			mute = true;
		} else {
			explode.GetComponent<AudioSource>().playOnAwake = true;
			shatter.GetComponent<AudioSource>().playOnAwake = true;
			shatter2.GetComponent<AudioSource>().playOnAwake = true;
			mute = false;
		}
	}
}
