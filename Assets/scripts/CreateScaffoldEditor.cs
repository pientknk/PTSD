#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateScaffold))]
public class CreateScaffoldEditor : Editor{

	private string[] options = new [] {"Vertical", "Horizontal", "Diag Right", "Diag Left"};
	int choiceIndex = 0;

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		CreateScaffold cs = (CreateScaffold)target;

		choiceIndex = EditorGUILayout.Popup ("Direction", choiceIndex, options);

		cs.Direction = choiceIndex;

		if (GUILayout.Button ("Create Scaffold")) {
			cs.BuildScaffold ();
		}

		if (GUILayout.Button ("Delete Scaffold")) {
			cs.DeleteScaffold ();
		}
	}
}
#endif
