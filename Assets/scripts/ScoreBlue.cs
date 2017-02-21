using UnityEngine;
using System.Collections;

public class ScoreBlue : MonoBehaviour {

	private float scoreBlue;

	// Use this for initialization
	void Start () {
		scoreBlue = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject score = GameObject.Find ("blueScore");
		score.GetComponent<TextMesh> ().text = scoreBlue.ToString();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if ((col.gameObject.name == "boxBlue(Clone)") || (col.gameObject.name == "boxCircleBlue(Clone)")) {
			scoreBlue++;
		} else if((col.gameObject.name == "boxOrange(Clone)") || (col.gameObject.name == "boxCircleOrange(Clone)"))  {
			scoreBlue--;
		}

		Destroy (col.gameObject);
	}
}
