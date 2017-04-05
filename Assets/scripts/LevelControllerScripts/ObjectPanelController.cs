using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelController : MonoBehaviour {


	private Button[] allButtons;
	private GameObject selectedObject;
	public Sprite switchRight;
	public Sprite switchLeft;
	public Sprite switchDisabled;
	// Use this for initialization
	void Start () {
		allButtons = transform.GetComponentsInChildren<Button> ();
		selectedObject = LevelController.instance.selectedObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelController.instance.selectedObject != null) {
			if (LevelController.instance.isPaused) {
				if (LevelController.instance.selectedObject.tag == "Conveyor") {
					allButtons [6].interactable = true;
					SurfaceEffector2D surface = LevelController.instance.selectedObject.GetComponent<SurfaceEffector2D> ();
					if (surface != null) {
						if (surface.speed < 0) {
							allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchLeft;
						} else {
							allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchRight;
						}
					} 
				} else {
					allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchDisabled;
					allButtons [6].interactable = false;
				}
				if (getSelectedObjectCost () > LevelController.instance.startingMoney) {
					allButtons [7].interactable = false;
				}
				if (getSelectedObjectCost () > LevelController.instance.startingMoney) {
					allButtons [0].interactable = false;
				}
			}
		}
			
		if (selectedObject != LevelController.instance.selectedObject) {
			selectedObject = LevelController.instance.selectedObject;
		}
		SetUpButtonActions ();
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
		LevelController.instance.startingMoney += getSelectedObjectCost() / 2;
		LevelController.instance.allBoughtObjects.Remove (theObject);
		Destroy (theObject);
		LevelController.instance.selectedObject = null;
		LevelController.instance.currentObjectCount--;
		UpdateButtons ();
	}

	private void HitOrange(GameObject theObject){
		theObject.layer = 9;
		foreach (Transform child in theObject.transform) {
			child.gameObject.layer = 9;
		}
		foreach (SpriteRenderer sprite in theObject.transform.GetComponentsInChildren<SpriteRenderer> ()) {
			sprite.color = new Color (1.0f, 0.6f, 0.0f, 0.5f);
		}
	}

	private void HitBlue(GameObject theObject){
		theObject.layer = 8;
		foreach (Transform child in theObject.transform) {
			child.gameObject.layer = 8;
		}
		foreach (SpriteRenderer sprite in theObject.transform.GetComponentsInChildren<SpriteRenderer> ()) {
			sprite.color = new Color(0.0f, 0.0f, 1.0f, 0.5f);
		}
	}

	private void HitBoth(GameObject theObject){
		theObject.layer = 0;
		foreach (Transform child in theObject.transform) {
			child.gameObject.layer = 0;
		}
		foreach (SpriteRenderer sprite in theObject.transform.GetComponentsInChildren<SpriteRenderer> ()) {
			sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

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
		SurfaceEffector2D surface = theObject.GetComponent<SurfaceEffector2D> ();
		if (surface != null) {
			surface.speed *= -1;
			if (surface.speed < 0) {
				allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchLeft;
			} else {
				allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchRight;
			}
		} else {
			allButtons [6].GetComponentsInChildren<Image> () [1].sprite = switchDisabled;
		}
	}

	private void Duplicate(GameObject theObject){
		int cost = getSelectedObjectCost ();
		LevelController.instance.startingMoney -= cost;
		GameObject clone = Instantiate (theObject);
		Vector3 pos = new Vector3 (theObject.transform.position.x + 20.0f, theObject.transform.position.y + 20.0f);
		clone.transform.position = pos;
		clone.transform.SetParent (LevelController.instance.theLevelObjects.transform);
		LevelController.instance.selectedObject = clone;
		LevelController.instance.currentObjectCount++;
		LevelController.instance.allBoughtObjects.Add (clone);
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

	private int getSelectedObjectCost(){
		
		GameObject selectedObject = LevelController.instance.selectedObject;
		if (selectedObject != null) {
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
			case "Funnel":
				objectCost = LevelController.instance.funnelCost;
				break;
			default:
				objectCost = 0;
				break;
			}
			return objectCost;
		} else {
			print ("Error: no selected object...objectpanelcontroller.cs");
			return 0;
		}

	}
}
