using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(TileMapCreator))]
public class TileMapInspector : Editor {

	public override void OnInspectorGUI ()
	{
		//base.OnInspectorGUI ();
		DrawDefaultInspector();

		if (GUILayout.Button ("Regenerate")) {
			TileMapCreator tileMap = (TileMapCreator)target;
			tileMap.BuildMesh ();
		}
	}
}
