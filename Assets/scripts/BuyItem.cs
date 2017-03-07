using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TheBank))]
public class BuyItem : MonoBehaviour {

	private TheBank bank;
	private bool canBuy;
	private string thisTag;
	private Button button;
	// Use this for initialization
	void Start () {
		bank = GetComponent<TheBank> ();
		thisTag = this.tag;
		button = GetComponent<Button>();
	}

	public void buyItem(){
		switch (thisTag){
		case "Conveyor":
			bank.subtractMoney (bank.ConveyorCost);
			break;
		case "Trampoline":
			bank.subtractMoney (bank.TrampolineCost);
			break;
		case "Slide":
			bank.subtractMoney (bank.SlideCost);
			break;
		case "Fan":
			bank.subtractMoney (bank.FanCost);
			break;
		case "Filter":
			bank.subtractMoney (bank.FilterCost);
			break;
		default:
			print ("Error: " + thisTag + " - must have an appropriate tag. e.g. Conveyor");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (thisTag){
		case "Conveyor":
			if (!bank.canBuyConveyor ()) {
				button.interactable = false;
			}
			break;
		case "Trampoline":
			if (!bank.canBuyTrampoline ()) {
				button.interactable = false;
			}
			break;
		case "Slide":
			if (!bank.canBuySlide ()) {
				button.interactable = false;
			}
			break;
		case "Fan":
			if (!bank.canBuyFan ()) {
				button.interactable = false;
			}
			break;
		case "Filter":
			if (!bank.canbBuyFilter ()) {
				button.interactable = false;
			}
			break;
		default:
			print ("Error: " + thisTag + " - must have an appropriate tag. e.g. Conveyor");
			break;
		}
	}
}
