using UnityEngine;
using UnityEngine.UI;

public class SummaryController : MonoBehaviour {

	public Text label;
	public bool package = false;
	public bool money = false;
	public bool items = false;
	public Sprite greenCheck;
	public Image packageImage;
	public Image moneyImage;
	public Image itemsImage;

	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
		if (package) {
			label.text = LevelController.instance.SuccessfulPackages.ToString();
			if (LevelController.instance.SuccessfulPackages >= LevelController.instance.packagesFor1Star) {
				packageImage.sprite = greenCheck;
				packageImage.color = Color.white;
				LevelController.instance.starsEarned++;
			}
		} else if (money) {
			label.text = LevelController.instance.currentMoney.ToString();
			if (LevelController.instance.currentMoney >= LevelController.instance.moneyFor1Star) {
				moneyImage.sprite = greenCheck;
				moneyImage.color = Color.white;
				LevelController.instance.starsEarned++;
			}
		} else if (items) {
			label.text = LevelController.instance.currentObjectCount.ToString();
			if (LevelController.instance.currentObjectCount <= LevelController.instance.currentObjectCount) {
				itemsImage.sprite = greenCheck;
				itemsImage.color = Color.white;
				LevelController.instance.starsEarned++;
			}
		} else {
			print ("you must select one of the public bools to true in the summary panel");
		}
	}
}
