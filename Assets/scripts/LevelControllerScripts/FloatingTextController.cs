using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

	private static FloatingText popupTextPrefab;
	private static GameObject canvas;

	public static void Initialize(){
		popupTextPrefab = Resources.Load<FloatingText>("Prefabs/UI/Popup Text Parent");
		canvas = LevelController.instance.levelCanvas;
	}

	public static void CreateFloatingText(string text, Vector3 location){
		FloatingText instance = Instantiate (popupTextPrefab);
		instance.transform.SetParent (canvas.transform, false);
		float height = 10.0f;
		//Vector3 screenLocation = Camera.allCameras[0].WorldToScreenPoint(location);
		Vector3 modifiedLocation = new Vector3 (location.x, location.y + height, location.z);
		instance.transform.position = modifiedLocation;
		instance.setText (text);
	}
}
