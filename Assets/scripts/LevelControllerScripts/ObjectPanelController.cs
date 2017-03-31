using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelController : MonoBehaviour {


	private Button[] allButtons;
	// Use this for initialization
	void Start () {
		allButtons = transform.GetChild (0).GetComponentsInChildren<Button> ();

	}
	
	// Update is called once per frame
	void Update () {
		UpdateButtons ();
	}

	void UpdateButtons(){
		if (LevelController.instance.selectedObject == null || !LevelController.instance.isPaused) {
			foreach (Button button in allButtons) {
				button.interactable = false;
			}
		} else {
			foreach (Button button in allButtons) {
				button.interactable = true;
			}
		}
	}

	private void Sell(GameObject theObject){
		if (LevelController.instance.isPaused) {
			GameObject selectedObject = LevelController.instance.selectedObject;
			string tag = selectedObject.tag;
			int objectCost;
			switch (tag) {
			case "Conveyor":
				objectCost = LevelController.instance.conveyorCost;
				break;
			case "Trampoline":
				objectCost = LevelController.instance.trampolineCost;
				break;
			case "Slide":
				objectCost = LevelController.instance.slideCost;
				break;
			case "Fan":
				objectCost = LevelController.instance.fanCost;
				break;
			case "Glue":
				objectCost = LevelController.instance.glueCost;
				break;
			case "Magnet":
				objectCost = LevelController.instance.magnetCost;
				break;
			default:
				objectCost = 0;
				break;
			}
			Destroy (theObject);
			LevelController.instance.selectedObject = null;

			LevelController.instance.startingMoney += objectCost / 2;
			UpdateButtons ();

			// update selector to be gone
			SelectedShower.Instance.removeUI ();
			SelectedShower.Instance.SelectedObject = null;
		}
	}
}
