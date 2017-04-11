using UnityEngine;

public class RotateAnimation : MonoBehaviour {
	
	public float speed = -550.0f;


	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.IsPaused) {
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed));
		}
	}
}
