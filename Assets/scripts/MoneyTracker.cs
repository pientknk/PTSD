using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour {
	//updates anytime a package fails or succeeds and either adds or substracts the amount to the total
	private static float money;
	private Text moneyLabel;
	public float Money{
		get{
			return money;
		}
		set{
			money = value;
		}
	}

	// Use this for initialization
	void Start () {
		moneyLabel = GetComponent<Text> ();
		money = 0;
	}
	
	// Update is called once per frame
	void Update () {
		moneyLabel.text = "$" + money;
	}
}
