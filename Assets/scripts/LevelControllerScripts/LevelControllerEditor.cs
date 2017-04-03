using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelController))]
public class LevelControllerEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		LevelController controller = (LevelController)target;

		if (GUILayout.Button ("Generate Random Packages")) {
			controller.AutoGenerate ();
		}
	}
}
