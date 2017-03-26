using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//should be placed in only one scene
public class GameController : MonoBehaviour {

	public static GameController controller;
	public int totalStars;
	public int money;
	public int levelsUnlocked;

	public float health;
	public float experience;
	// Awake occurs before Start
	// this makes it so that there can only be one of these objects in any scene
	void Awake(){
		if (controller == null) {
			// makes it persist from scene to scene
			DontDestroyOnLoad (gameObject);
			controller = this;
		} else if(controller != this){
			Destroy (gameObject);
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
		GUI.Label(new Rect(10, 40, 150, 30), "Exp: " + experience);
	}

	//saves data out to a binary file
	public void Save(){
		//open file where data will be saved
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		// update the file to be saved by getting current user data
		UserData data = new UserData ();
		data.health = health;
		data.experience = experience;

		//write to file and close it
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			UserData data = (UserData)bf.Deserialize (file);
			file.Close();

			health = data.health;
			experience = data.experience;
		}
	}


}
	
// should reflect the instance variables and other data needed to save the game
// needs to be serializable to be able to write to a file
[Serializable]
class UserData{
	public int levelsUnlocked;
	public int totalStars;
	public int money;
	public float health;
	public float experience;
}
