using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages all the buttons used to buy new objects.
/// </summary>
public class BuyObjectButtonManager : MonoBehaviour {

	private Button[] allButtons;

	// Use this for initialization
	void Start () {
		allButtons = gameObject.GetComponentsInChildren<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelController.instance.IsPaused) {
			foreach (Button button in allButtons) {
				button.interactable = false;
			}
		} else {
			foreach (Button button in allButtons) {
				button.interactable = true;
			}
			CheckBuyButtons ();
		}
	}

	/// <summary>
	/// Updates the buttons interactive state based on how much money the player has
	/// </summary>
	private void CheckBuyButtons(){
		float currentMoney = LevelController.instance.startingMoney;
		if (currentMoney < LevelController.instance.SlideCost) {
			allButtons [0].interactable = false;
		} else {
			allButtons [0].interactable = true;
		}
		if (currentMoney < LevelController.instance.ConveyorCost) {
			allButtons [1].interactable = false;
		} else {
			allButtons [1].interactable = true;
		}
		if (currentMoney < LevelController.instance.TrampolineCost) {
			allButtons [2].interactable = false;
		} else {
			allButtons [2].interactable = true;
		}
		if (currentMoney < LevelController.instance.GlueCost) {
			allButtons [3].interactable = false;
		} else {
			allButtons [3].interactable = true;
		}
		if (currentMoney < LevelController.instance.FunnelCost) {
			allButtons [4].interactable = false;
		} else {
			allButtons [4].interactable = true;
		}
		if (currentMoney < LevelController.instance.FanCost) {
			allButtons [5].interactable = false;
		} else {
			allButtons [5].interactable = true;
		}
		if (currentMoney < LevelController.instance.MagnetCost) {
			allButtons [6].interactable = false;
		} else {
			allButtons [6].interactable = true;
		}
	}
}
