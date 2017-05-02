using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkShader : MonoBehaviour {

	private Texture2D customMask = null;
	private Color defaultColor = Color.black;
	private Color clear = Color.clear;
	private Vector2 areaLocation;
	private Rect areaSize;
	private float leftSide;
	private float rightSide;
	private float topSide;
	private float bottomSide;

	public Transform areaTransform;
	public GUITexture guiTexture;

	void Start(){
		if (areaTransform != null) {
			areaLocation = Camera.main.WorldToScreenPoint(areaTransform.position);
			print ("Location: " + areaLocation);
			areaSize = areaTransform.GetComponent<RectTransform> ().rect;
			leftSide = areaLocation.x - areaSize.xMin;
			rightSide = areaLocation.x + areaSize.xMax;
			topSide = areaLocation.y + areaSize.yMax;
			bottomSide = areaLocation.y - areaSize.yMin;
			print ("L: " + leftSide + " R: " + rightSide + " T: " + topSide + " B: " + bottomSide);
		}
	}

	private void CreateMask(){
		customMask = new Texture2D (Screen.width, Screen.height);

		int y = 0;
		while (y < customMask.height) {
			int x = 0;
			while (x < customMask.width) {
				//exclude pixels that are within the area that should be transparent
				if (areaTransform != null) {
					//customMask.SetPixel (x, y, clear);
				} else {
					print ("Need to assign a transform");
					customMask.SetPixel(x, y, defaultColor);
				}
				x++;
			}
			y++;
		}

		customMask.Apply ();
		guiTexture.texture = customMask;
		customMask.Apply ();
	}
}
