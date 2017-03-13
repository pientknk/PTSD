using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TheBank))]
public class ScoreBlue : MonoBehaviour {

	private float scoreBlue;
	private TheBank bank;
	private int worth = 50;
	private int profit = 0;
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
			scoreBlue++;
			int money = (int)(worth * (cf.GetHealth() / cf.GetMaxHealth()));
			bank.addMoney (money);
			Profit += money;
		} else if(tag == "orange item"){
			scoreBlue--;
			bank.subtractMoney (worth);
			Profit -= worth;
		}

		print (col.gameObject.name + " had " + cf.GetHealth() + " health left");

		Destroy (col.gameObject);

	}
}
