using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class GameController{

	public static bool tooltip;
	public static bool music;
	public static bool sounds;

	public static void DeleteAll(){
		PlayerPrefs.DeleteKey ("tooltip");
		PlayerPrefs.DeleteKey ("music");
		PlayerPrefs.DeleteKey ("sound");
	}

	//saves data out to player prefs
	public static void Save(int tool, int mus, int sound){
		PlayerPrefs.SetInt("tooltip", tool);
		PlayerPrefs.SetInt ("music", mus);
		PlayerPrefs.SetInt ("sound", sound);

	}

	//loads data out of player prefs
	public static void Load(){
		if (PlayerPrefs.HasKey ("tooltip")) {
			if (PlayerPrefs.GetInt ("tooltip") == 1) {
				tooltip = true;
			} else {
				tooltip = false;
			}
		} else {
			tooltip = true;
		}
		if (PlayerPrefs.HasKey ("music")) {
			if (PlayerPrefs.GetInt ("music") == 1) {
				music = true;
			} else {
				music = false;
			}
		} else {
			music = true;
		}
		if (PlayerPrefs.HasKey ("sound")) {
			if (PlayerPrefs.GetInt ("sound") == 1) {
				sounds = true;
			} else {
				sounds = false;
			}
		} else {
			sounds = true;
		}
	}
}
