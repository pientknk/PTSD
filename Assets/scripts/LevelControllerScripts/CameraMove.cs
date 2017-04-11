using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	//camera boundary and movement
	public float boundary = 50.0f; // distance from edge scrolling starts
	public int speed = 50;
	public int fastSpeed = 100;
	private int theScreenWidth;
	private int theScreenHeight;

	//camera field of view
	private float minSize = 150.0f;
	private float maxSize = 300.0f;
	private float sensitivity = 10f;
	private Rect screenRect;
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private float camMinX;
	private float camMaxX;
	private float camMinY;
	private float camMaxY;

	void Start() 
	{
		theScreenWidth = Screen.width;
		theScreenHeight = Screen.height;
		screenRect = new Rect(0, 0, Screen.width, Screen.height);
		Rect levelObjectsRect = LevelController.instance.theLevelObjects.GetComponent<RectTransform> ().rect;
		Rect cameraRect = Camera.allCameras [0].rect;
		minX = levelObjectsRect.xMin;
		maxX = levelObjectsRect.xMax;
		minY = levelObjectsRect.yMin;
		maxY = levelObjectsRect.yMax;
		print ("Thelevelobjects locations: " + minX + " " + maxX + " " + minY + " " + maxY);
	}

	void Update() 
	{
		if (screenRect.Contains (Input.mousePosition)) {
			if (Input.mousePosition.x > theScreenWidth - boundary) {
				Vector3 newPos = transform.position;
				//newPos.x += speed * Time.deltaTime;
				newPos.x += speed;
				transform.position = newPos; // move on +X axis
			}
			if (Input.mousePosition.x < 0 + boundary) {
				Vector3 newPos = transform.position;
				//newPos.x -= speed * Time.deltaTime;
				newPos.x -= speed;
				transform.position = newPos; // move on -X axis
			}
			if (Input.mousePosition.y > theScreenHeight - boundary) {
				Vector3 newPos = transform.position;
				//newPos.y += speed * Time.deltaTime;
				newPos.y += speed;
				transform.position = newPos; // move on +Z axis
			}
			if (Input.mousePosition.y < 0 + boundary) {
				Vector3 newPos = transform.position;
				//newPos.y -= speed * Time.deltaTime;
				newPos.y -= speed;
				transform.position = newPos; // move on -Z axis
			}

			float size = Camera.allCameras [0].orthographicSize;
			size += Input.GetAxis ("Mouse ScrollWheel") * sensitivity;
			size = Mathf.Clamp (size, minSize, maxSize);
			Camera.allCameras [0].orthographicSize = size;
		}
	}

}
