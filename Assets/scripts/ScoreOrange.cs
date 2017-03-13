using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class ScoreOrange : MonoBehaviour {

	private float scoreOrange;
	private TheBank bank;
	private int worth = 50;
	private int profit;
	public int Profit{
		get{
			return profit;
		}
		set{
			profit = value;
		}
	}

	// Use this for initialization
	void Start () {
		scoreOrange = 0;
		bank = GetComponent<TheBank> ();
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
			scoreOrange++;
			int money = (int)(worth * (cf.GetHealth() / cf.GetMaxHealth()));
			bank.addMoney (money);
			Profit += money;
		} else if(tag == "blue item"){
			scoreOrange--;
			bank.subtractMoney (worth);
			Profit -= worth;
		}

		print (col.gameObject.name + " had " + cf.GetHealth() + " health left");

		Destroy (col.gameObject);
	}
}
