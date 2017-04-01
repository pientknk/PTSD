using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelController : MonoBehaviour {


	private Button[] allButtons;
	private GameObject selectedObject;
	// Use this for initialization
	void Start () {
		allButtons = transform.GetChild (0).GetComponentsInChildren<Button> ();
		selectedObject = LevelController.instance.selectedObject;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateButtons ();
		if (selectedObject != LevelController.instance.selectedObject) {
			selectedObject = LevelController.instance.selectedObject;
			SetUpButtonActions ();
		}
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

	}

	private void HitOrange(GameObject theObject){
		theObject.layer = 9;
		theObject.transform.GetComponentInChildren<Image> ().color = new Color (1.0f, 0.6f, 0.0f, 0.9f);
	}

	private void HitBlue(GameObject theObject){
		theObject.layer = 8;
		theObject.transform.GetComponentInChildren<Image> ().color = Color.blue;
	}

	private void HitBoth(GameObject theObject){
		theObject.layer = 0;
		theObject.transform.GetComponentInChildren<Image> ().color = Color.white;
	}

	private void RotateLeft(GameObject theObject){
		Vector3 rotation = theObject.transform.rotation.eulerAngles;
		rotation += (Vector3.forward * 15.0f);
		theObject.transform.eulerAngles = rotation;
	}

	private void RotateRight(GameObject theObject){
		Vector3 rotation = theObject.transform.rotation.eulerAngles;
		rotation += (Vector3.back * 15.0f);
		theObject.transform.eulerAngles = rotation;
	}

	private void Switch(GameObject theObject){

	}

	private void Duplicate(GameObject theObject){

	}

	private void SetUpButtonActions(){
		foreach (Button button in allButtons) {
			button.onClick.RemoveAllListeners ();
		}
		allButtons[0].onClick.AddListener (delegate {
			Sell(selectedObject);
		});
		allButtons[1].onClick.AddListener (delegate {
			HitOrange(selectedObject);
		});
		allButtons[2].onClick.AddListener (delegate {
			HitBlue(selectedObject);
		});
		allButtons[3].onClick.AddListener (delegate {
			HitBoth(selectedObject);
		});
		allButtons[4].onClick.AddListener (delegate {
			RotateLeft(selectedObject);
		});
		allButtons[5].onClick.AddListener (delegate {
			RotateRight(selectedObject);
		});
		allButtons[6].onClick.AddListener (delegate {
			Switch(selectedObject);
		});
		allButtons[7].onClick.AddListener (delegate {
			Duplicate(selectedObject);
		});
	}
}
