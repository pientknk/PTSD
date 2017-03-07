using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TheBank))]
public class updateItemCost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TheBank bank = GetComponent<TheBank> ();
		Text label = GetComponent<Text> ();
		switch (this.tag){
		case "Conveyor":
			label.text = "Conveyor - $" + bank.ConveyorCost;
			break;
		case "Trampoline":
			label.text = "Trampoline - $" + bank.TrampolineCost;
			break;
		case "Slide":
			label.text = "Slide - $" + bank.SlideCost;
			break;
		case "Fan":
			label.text = "Fan - $" + bank.FanCost;
			break;
		case "Filter":
			label.text = "Filter - $" + bank.FilterCost;
			break;
		default:
			label.text = "Unknown";
			print ("Error: " + this.tag + " - must have an appropriate tag. e.g. Conveyor");
			break;
		}
	}
	
}
