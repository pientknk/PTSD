using UnityEngine;
using UnityEngine.UI;

public class SpendingMoney : MonoBehaviour {

	private Text label;
	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = "Funds: $" + LevelController.instance.startingMoney;
	}
}
