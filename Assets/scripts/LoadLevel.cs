using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add to canvas in every scene for menu navigation and loading of different scenes
public class LoadLevel : MonoBehaviour {

	public void LoadThisLevel(int level){
		Application.LoadLevel (level);
	}
}
