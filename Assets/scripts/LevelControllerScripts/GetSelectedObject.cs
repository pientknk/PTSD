using UnityEngine;

public class GetSelectedObject : MonoBehaviour {

	void OnMouseDown(){
		LevelController.instance.selectedObject = gameObject;
	}
}
