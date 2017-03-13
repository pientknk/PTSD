using UnityEngine;
using System.Collections;

//Was using this script to switch direction of converyor belt. No longer will be used but may be useful reference for
//future scripts
public class Switch : MonoBehaviour {
	
	private SurfaceEffector2D surface;
	// Use this for initialization
	void Start () {
		surface = GetComponent<SurfaceEffector2D> ();
	}

	// Update is called once per frame
	void OnMouseOver () {
		if (surface != null) {
			if (PausePlay.Instance.Paused) {

				if (Input.GetKeyDown (KeyCode.S)) {
					surface.speed *= -1;
				}
			}
		} else{
			print("No surface effector on this object!");
		}
	}
}
