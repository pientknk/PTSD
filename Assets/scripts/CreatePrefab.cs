using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour {

	// Use this for initialization
	void Start(){
	}

	public void createPrefab(GameObject prefab){
		GameObject clone = Instantiate(prefab) as GameObject;
		Canvas canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
		Vector2 S;
		if (canvas != null) {
			clone.transform.SetParent (canvas.transform);
			clone.transform.localPosition = new Vector2(0.0f, 0.0f);

			//check tag of object and make it the appropriate size
			switch (this.tag){
			case "Conveyor":
				S = clone.GetComponent<RectTransform>().sizeDelta;
				clone.GetComponent<BoxCollider2D> ().size = S;
				break;
			case "Trampoline":
				S = clone.GetComponent<RectTransform>().sizeDelta;
				clone.GetComponent<BoxCollider2D> ().size = S;
				break;
			case "Slide":
				S = clone.GetComponent<RectTransform>().sizeDelta;
				clone.GetComponent<BoxCollider2D> ().size = S;
				break;
			case "Fan":
				S = clone.GetComponent<RectTransform>().sizeDelta;
				clone.GetComponent<BoxCollider2D> ().size = S;
				break;
			case "Filter":
				S = clone.GetComponent<RectTransform>().sizeDelta;
				clone.GetComponent<BoxCollider2D> ().size = S;
				break;
			default:
				print ("Error: unable to create an object in CreatePrefab.cs");
				break;
			}

		}

	}
}
