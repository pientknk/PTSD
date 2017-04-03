using UnityEngine;

public class CreateBuyableObject : MonoBehaviour {

	/// <summary>
	/// Creates the given usable object and puts it centered on the screen
	/// </summary>
	/// <param name="prefab">Parameter to pass.</param>
	public void CreateUsableObject(GameObject prefab){
		GameObject clone = Instantiate (prefab);
		LevelController.instance.currentObjectCount++;
		//make it a child of TheLevelObjects and center it to where the camera is
		clone.transform.SetParent (LevelController.instance.theLevelObjects.transform, false);
		Camera cam = Camera.allCameras[0];
		Vector2 center = cam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f));
		clone.transform.position = center;

		//set selected object to this new object so that way the showSelected will highlight it
		LevelController.instance.selectedObject = clone;

		SubtractAvailableMoney (clone);
		LevelController.instance.allBoughtObjects.Add (clone);
	}

	/// <summary>
	/// Subtracts the cost of the bought item from the available money.
	/// </summary>
	/// /// <param name="prefab">Parameter to pass.</param>
	private void SubtractAvailableMoney(GameObject prefab){
		int amount = 0;
		switch (prefab.tag) {
		case "Conveyor":
			amount = LevelController.instance.conveyorCost;
			break;
		case "Trampoline":
			amount = LevelController.instance.trampolineCost;
			break;
		case "Slide":
			amount = LevelController.instance.slideCost;
			break;
		case "Fan":
			amount = LevelController.instance.fanCost;
			break;
		case "Glue":
			amount = LevelController.instance.glueCost;
			break;
		case "Magnet":
			amount = LevelController.instance.magnetCost;
			break;
		default:
			print ("Error in CreateBuyableObject.cs: " + this.tag + " - must have an appropriate tag. e.g. Conveyor");
			break;
		}
		LevelController.instance.startingMoney -= amount;
	}
}
