using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class ScoreBlue : MonoBehaviour {

	private float scoreBlue;
	private TheBank bank;
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
	private MoneyTracker mt;
	private DeliveringPackagesCounter dpc;
	// Use this for initialization
	void Start () {
		dpc = GameObject.FindGameObjectWithTag ("successfailure").GetComponent<DeliveringPackagesCounter> ();
		scoreBlue = 0;
		bank = GetComponent<TheBank> ();
		mt = GameObject.FindGameObjectWithTag ("Money").GetComponent<MoneyTracker> ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		// check what kind of item has entered
		CalcForce cf = col.gameObject.GetComponent<CalcForce>();
		string tag = col.gameObject.tag;
		if (tag == "blue item"){
			dpc.SuccessCount += 1;
			scoreBlue++;
			float tempMoney = cf.GetMaxHealth() * (cf.GetHealth() / cf.GetMaxHealth());
			int money = (int)tempMoney;
			mt.Money += money;
			Destroy (col.gameObject);
		} else if(tag == "orange item"){
			dpc.FailCount += 1;
			scoreBlue--;
			mt.Money -= 50;
			Destroy (col.gameObject);
		}
		//print (col.gameObject.name + " had " + cf.GetHealth() + " health left");
	}
}
