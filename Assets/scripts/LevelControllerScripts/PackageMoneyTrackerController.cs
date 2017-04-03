using UnityEngine;
using UnityEngine.UI;

public class PackageMoneyTrackerController : MonoBehaviour {

	private Text successText;
	private Text failText;
	public Text moneyLabel;
	private int money;
	private int packagesDestroyed;
	// Use this for initialization
	void Start () {
		successText = GetComponentsInChildren<Text> () [0];
		failText = GetComponentsInChildren<Text> () [1];
		money = LevelController.instance.currentMoney;
	}
	
	// Update is called once per frame
	void Update () {
		int successCount = LevelController.instance.SuccessfulPackages;
		int failureCount = LevelController.instance.FailurePackages;
		packagesDestroyed = successCount + failureCount;
		successText.text = "x" + successCount;
		failText.text = "x" + failureCount;
		if (money != LevelController.instance.currentMoney) {
			int initial = money;
			money = LevelController.instance.currentMoney;
			gameObject.AddComponent<TextChangeController> ().Create (moneyLabel, initial, money);
		} else {
			moneyLabel.text = money.ToString ();
		}

		if (packagesDestroyed == LevelController.instance.allPackages.Count) {
			print ("Done with level");
			LevelController.instance.summaryCanvas.SetActive (true);
			LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
		}
	}
}
