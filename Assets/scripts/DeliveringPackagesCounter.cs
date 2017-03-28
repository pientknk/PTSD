using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveringPackagesCounter : MonoBehaviour {

	private static int successCount;
	public int SuccessCount{
		get{
			return successCount;
		}
		set{
			successCount = value;
		}
	}
	private static int failCount;
	public int FailCount{
		get{
			return failCount;
		}
		set{
			failCount = value;
		}
	}

	private Text successText;
	private Text failText;

	private ProgressesController pc;
	// Use this for initialization
	void Start () {
		pc = GameObject.Find ("Progress Panel").GetComponent<ProgressesController>();
		successCount = 0;
		successText = GetComponentsInChildren<Text> ()[0];
		failText = GetComponentsInChildren<Text> () [1];
	}
	
	// Update is called once per frame
	void Update () {
		pc.UpdatePackageProgress();
		successText.text = "x" + successCount;
		failText.text = "x" + failCount;
	}
}
