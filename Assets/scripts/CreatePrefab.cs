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

			// set the selector to be on the new bought object
			SelectedShower.Instance.removeUI ();
			SelectedShower.Instance.SelectedObject = clone;
			SelectedShower.Instance.addUI ();

			S = clone.GetComponent<RectTransform>().sizeDelta;
			clone.GetComponent<BoxCollider2D> ().size = S;

		}

	}
}
