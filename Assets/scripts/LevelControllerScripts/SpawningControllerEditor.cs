#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawningController))]
public class SpawningControllerEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		SpawningController controller = (SpawningController)target;

		if (GUILayout.Button ("Generate Random Packages")) {
			controller.AutoGenerate ();
		}
	}
}

#endif
