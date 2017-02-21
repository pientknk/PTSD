using UnityEngine;
using System.Collections;

public class ScoreOrange : MonoBehaviour {

	private float scoreOrange;

	// Use this for initialization
	void Start () {
		scoreOrange = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject score = GameObject.Find ("orangeScore");
		score.GetComponent<TextMesh> ().text = scoreOrange.ToString();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if ((col.gameObject.name == "boxOrange(Clone)") || (col.gameObject.name == "boxCircleOrange(Clone)")) {
			scoreOrange++;
		} else if ((col.gameObject.name == "boxBlue(Clone)") || (col.gameObject.name == "boxCircleBlue(Clone)")) {
			scoreOrange--;
		}

		Destroy (col.gameObject);
	}
}
