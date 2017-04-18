using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScaffold : MonoBehaviour {

	public int numberOfPieces = 2;
	private int direction = 0;
	public int Direction{
		set{ direction = value; }
	}
	public GameObject ObjectToCreate;
	private GameObject[] AllScaffold;

	public void BuildScaffold(){
		AllScaffold = new GameObject[numberOfPieces];
		RectTransform scaffoldRect = ObjectToCreate.GetComponent<RectTransform> ();
		float height = scaffoldRect.rect.height;
		float width = scaffoldRect.rect.width;
		Vector3 scale = scaffoldRect.transform.localScale;
		// for every piece of scaffold, instantiate and position it line according to direction
		for (int i = 0; i < numberOfPieces; i++) {
			GameObject newScaffold = Instantiate (ObjectToCreate);
			// set parent and position to center of parent
			newScaffold.transform.SetParent (transform);
			newScaffold.transform.position = transform.position;

			AllScaffold [i] = newScaffold;

			//modify its position according to the direction
			newScaffold.transform.position = CalculateNewPosition (newScaffold.transform.position, width, height, scale, i);
		}
	}

	private Vector3 CalculateNewPosition(Vector3 pos, float width, float height, Vector3 scale, int index){
		Vector3 newPosition = pos;
		switch (direction) {
		//vertical
		case 0:
			newPosition.y -= height * scale.y * index;
			break;
		//horizontal
		case 1:
			newPosition.x += width * scale.x * index;
			break;
		//diagonal right
		case 2:
			newPosition.y += height * scale.y * index;
			newPosition.x += width * scale.x * index;
			break;
		//diagonal left
		case 3:
			newPosition.y += height * scale.y * index;
			newPosition.x -= width * scale.x * index;
			break;
		default:
			print ("Error, unknown direction");
			break;
		}
		return newPosition;
	}

	public void DeleteScaffold(){
		foreach(Transform child in transform){
			DestroyImmediate (child.gameObject);
		}
	}
}
