using UnityEngine;

public class RotateAnimation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.isPaused) {
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * -550));
		}
	}
}
