using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {

	public Sprite checkMark;
	public Sprite redX;
	public Image moneyStatus;
	public Image packageStatus;
	public Image objectStatus;

	private Text moneyLabel;
	private Text packageLabel;
	private Text objectCountLabel;

	public GameObject moneyProgressBar;
	public GameObject packageProgressBar;
	public GameObject objectsUsedProgressBar;

	private Image moneyBarImage;
	private Image packageBarImage;
	private Image objectBarImage;

	private Color originalColor;
	private Color completedColor = Color.green;
	private Color redXColor = new Color32(110, 110, 110, 255);
	private Color checkColor = Color.white;
	// Use this for initialization
	void Start () {
		// get access to the labels on each progress bar
		moneyLabel = moneyProgressBar.transform.GetChild (2).GetComponent<Text> ();
		packageLabel = packageProgressBar.transform.GetChild (2).GetComponent<Text> ();
		objectCountLabel = objectsUsedProgressBar.transform.GetChild (2).GetComponent<Text> ();

		// get access to the foreground image of each progress bar to update it and show progress visually
		moneyBarImage = moneyProgressBar.transform.GetChild (1).GetComponent<Image> ();
		packageBarImage = packageProgressBar.transform.GetChild (1).GetComponent<Image> ();
		objectBarImage = objectsUsedProgressBar.transform.GetChild (1).GetComponent<Image> ();

		//get the original color of the progress bars image, should be blue
		originalColor = moneyBarImage.color;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMoneyProgress ();
		UpdatePackageProgress ();
		UpdateObjectProgress ();
	}

	/// <summary>
	/// Updates the money progress bar and label.
	/// </summary>
	private void UpdateMoneyProgress(){
		string moneyCount;
		int currentMoney = LevelController.instance.currentMoney;
		int moneyNeeded = LevelController.instance.moneyFor1Star;
		if (currentMoney < 0) {
			moneyCount = "0/" + moneyNeeded;
			moneyBarImage.fillAmount = 0;
			moneyStatus.sprite = redX;
			moneyStatus.color = redXColor;
		} else if(currentMoney >= moneyNeeded){
			moneyCount = currentMoney + "/" + moneyNeeded;
			moneyBarImage.color = completedColor;
			moneyBarImage.fillAmount = 1;
			moneyStatus.sprite = checkMark;
			moneyStatus.color = checkColor;
		} else{
			moneyCount = currentMoney + "/" + moneyNeeded;
			moneyBarImage.color = originalColor;
			if (currentMoney == 0) {
				moneyBarImage.fillAmount = 0;
			} else {
				moneyBarImage.fillAmount = currentMoney / moneyNeeded;
			}
			moneyStatus.sprite = redX;
			moneyStatus.color = redXColor;
		}
		moneyLabel.text = moneyCount;
	}

	/// <summary>
	/// Updates the package progress bar and label.
	/// </summary>
	private void UpdatePackageProgress(){
		int successPackages = LevelController.instance.SuccessfulPackages;
		int packagesNeeded = LevelController.instance.packagesFor1Star;
		if (successPackages >= packagesNeeded) {
			packageBarImage.color = completedColor;
			packageBarImage.fillAmount = 1;
			packageStatus.sprite = checkMark;
			packageStatus.color = checkColor;
		} else {
			packageBarImage.color = originalColor;
			if (successPackages == 0) {
				packageBarImage.fillAmount = 0;
			} else {
				packageBarImage.fillAmount = (float)successPackages / (float)packagesNeeded;
			}
			packageStatus.sprite = redX;
			packageStatus.color = redXColor;
		}
		packageLabel.text = successPackages + "/" + packagesNeeded;
	}

	/// <summary>
	/// Updates the package progress bar and label.
	/// </summary>
	private void UpdateObjectProgress(){
		int curObjectCount = LevelController.instance.currentObjectCount;
		int maxObjects = LevelController.instance.maxObjectsUsedFor1Star;
		if (curObjectCount > maxObjects) {
			objectBarImage.fillAmount = 0;
			objectCountLabel.text = (maxObjects - curObjectCount) + " Item(s) Left";
			objectStatus.sprite = redX;
			objectStatus.color = redXColor;
		} else {
			if (curObjectCount == 0) {
				objectBarImage.fillAmount = 1;
			} else {
				float percentUsed = (float)curObjectCount / (float)maxObjects;
				objectBarImage.fillAmount = 1.0f - percentUsed;
			}
			objectStatus.sprite = checkMark;
			objectStatus.color = checkColor;
			objectCountLabel.text = (maxObjects - curObjectCount) + " Item(s) Left";
		}

	}
}
