using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class ScoreBlue : MonoBehaviour {

	private float scoreBlue;
	private TheBank bank;
	private int worth = 100;
	private int profit = 0;
	private int successes;
	private int failures;
	public int Profit{
		get{
			return profit;
		}
		set{
			profit = value;
		}
	}

	private DeliveringPackagesCounter dpc;
	// Use this for initialization
	void Start () {
		dpc = GameObject.FindGameObjectWithTag ("successfailure").GetComponent<DeliveringPackagesCounter> ();
		scoreBlue = 0;
		bank = GetComponent<TheBank> ();
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject score = GameObject.Find ("blueScore");
		//score.GetComponent<TextMesh> ().text = scoreBlue.ToString();
	}

	void OnCollisionEnter2D(Collision2D col) {
		// check what kind of item has entered
		CalcForce cf = col.gameObject.GetComponent<CalcForce>();
		string tag = col.gameObject.tag;
		if (tag == "blue item"){
			successes = dpc.SuccessCount;
			successes++;
			dpc.SuccessCount = successes;
			scoreBlue++;
			int money = (int)(worth * (cf.GetHealth() / cf.GetMaxHealth()));
			bank.addMoney (money);
			Profit += money;
		} else if(tag == "orange item"){
			failures = dpc.FailCount;
			failures++;
			dpc.FailCount = failures;
			scoreBlue--;
			bank.subtractMoney (worth);
			Profit -= worth;
		}

		//print (col.gameObject.name + " had " + cf.GetHealth() + " health left");

		Destroy (col.gameObject);

	}
}
