using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlAdjuster : MonoBehaviour {

	void OnGUI(){
		if(GUI.Button(new Rect(10, 100, 100, 30), "Health up")){
			GameController.controller.health += 10;
		}
	}
}
