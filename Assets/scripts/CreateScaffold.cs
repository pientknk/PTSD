using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateScaffold : MonoBehaviour {

	public int numberOfPieces = 2;
	public GameObject scaffold;
	// Use this for initialization
	void Start () {
		
		RectTransform scaffoldRectTransform = GameObject.FindGameObjectWithTag("scaffold").GetComponent<RectTransform>();
		if (scaffoldRectTransform != null) {
			scaffoldRectTransform = scaffoldRectTransform.transform as RectTransform;
		}

		// for every piece of scaffold, instantiate and position it line to the right of the previous one
		for (int i = 0; i < numberOfPieces; i++) {
			//GameObject newScaffold = Instantiate (scaffold);
			Vector3 parentPosition = scaffoldRectTransform.position;
			//newScaffold.transform.SetParent ();
		}
	}
}
