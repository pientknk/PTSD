using UnityEngine;
using UnityEngine.UI;

public class PackageMoneyTrackerController : MonoBehaviour {

	private Text successText;
	private Text failText;
	private Text moneyText;
	// Use this for initialization
	void Start () {
		successText = GetComponentsInChildren<Text> () [0];
		failText = GetComponentsInChildren<Text> () [1];
		moneyText = GetComponentsInChildren<Text> () [2];
	}
	
	// Update is called once per frame
	void Update () {
		successText.text = "x" + LevelController.instance.successfulPackages;
		failText.text = "x" + LevelController.instance.failurePackages;
		moneyText.text = "$" + LevelController.instance.currentMoney;
	}
}
