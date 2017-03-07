using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TheBank))]
public class updateBank : MonoBehaviour {

	private TheBank bank;
	private Text label;
	// Use this for initialization
	void Start () {
		bank = GetComponent<TheBank> () as TheBank;
		label = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = "FUNDS: $" + bank.CurrentMoney;
	}
}
