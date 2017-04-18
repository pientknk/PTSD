#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Create))]
public class SpawnEditor : Editor{

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		Create create = (Create)target;
		if (GUILayout.Button ("Randomize")) {
				create.AutoGenerate ();
		}
		if (!create.autoGenerate) {
			EditorGUILayout.HelpBox ("You must have autoGenerate set before you can randomize.", MessageType.Info);
		}
	}
}

#endif
