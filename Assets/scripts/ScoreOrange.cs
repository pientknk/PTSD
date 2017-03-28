using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class ScoreOrange : MonoBehaviour {

	private TheBank bank;
	private int worth = 100;
	private int profit;
	public int Profit{
		get{
			return profit;
		}
		set{
			profit = value;
		}
	}
	private MoneyTracker mt;
	private DeliveringPackagesCounter dpc;
	// Use this for initialization
	void Start () {
		dpc = GameObject.FindGameObjectWithTag ("successfailure").GetComponent<DeliveringPackagesCounter> ();
		bank = GetComponent<TheBank> ();
		mt = GameObject.FindGameObjectWithTag ("Money").GetComponent<MoneyTracker> ();
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject score = GameObject.Find ("orangeScore");
		//score.GetComponent<TextMesh> ().text = scoreOrange.ToString();
	}

	void OnCollisionEnter2D(Collision2D col) {
		// check what kind of box has entered
		CalcForce cf = col.gameObject.GetComponent<CalcForce>();
		string tag = col.gameObject.tag;
		if (tag == "orange item"){
			dpc.SuccessCount += 1;
			int money = (int)(cf.GetMaxHealth() * (cf.GetHealth() / cf.GetMaxHealth()));
			mt.Money += money;
			Destroy (col.gameObject);
		} else if(tag == "blue item"){
			dpc.FailCount += 1;
			mt.Money -= 50;
			Destroy (col.gameObject);
		}

		//print (col.gameObject.name + " had " + cf.GetHealth() + " health left");
	}
}
