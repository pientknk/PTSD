using UnityEngine;
using UnityEngine.UI;

public class PackageCounterController : MonoBehaviour {

	private Text label;
	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = "x" + LevelController.instance.NumPackagesLeft;
	}
}
