using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour {

	// Use this for initialization
	public void createPrefab(GameObject prefab){
		GameObject clone = Instantiate(prefab) as GameObject;
		Canvas canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
		if (canvas != null) {
			clone.transform.SetParent (canvas.transform);
			clone.transform.localPosition = new Vector2(0.0f, 0.0f);
			RectTransform cloneRect = GetComponent<RectTransform> ();
			//check tag of object and make it the appropriate size
			switch (this.tag){
			case "Conveyor":
				//clone.transform.localScale = new Vector3 (2.0f, 2.0f);
				cloneRect.sizeDelta = new Vector2 (100f, 40f);
				break;
			case "Trampoline":
				break;
			case "Slide":
				break;
			case "Fan":
				break;
			case "Filter":
				break;
			default:
				print ("Error: unable to create an object in CreatePrefab.cs");
				break;
			}

		}

	}
}
