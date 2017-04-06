using UnityEngine;
using UnityEngine.UI;

public class UsableObjectCost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text label = GetComponent<Text> ();
		switch (this.tag){
		case "Conveyor":
			label.text = "Conveyor - $" + LevelController.instance.conveyorCost;
			break;
		case "Trampoline":
			label.text = "Trampoline - $" + LevelController.instance.trampolineCost;
			break;
		case "Slide":
			label.text = "Slide - $" + LevelController.instance.slideCost;
			break;
		case "Fan":
			label.text = "Fan - $" + LevelController.instance.fanCost;
			break;
		case "Glue":
			label.text = "Glue - $" + LevelController.instance.glueCost;
			break;
		case "Magnet":
			label.text = "Magnet - $" + LevelController.instance.magnetCost;
			break;
		case "Funnel":
			label.text = "Funnel - $" + LevelController.instance.funnelCost;
			break;
		default:
			label.text = "Unknown";
			print ("Error: " + this.tag + " - must have an appropriate tag. e.g. Conveyor");
			break;
		}
	}
}
