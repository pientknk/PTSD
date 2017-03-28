using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelController : MonoBehaviour{

	private static ModifyActions ma;
	private static GameObject panel;
	public static ModifyActions Ma{
		get{ return ma; }
	}

	void Start(){
		panel = GameObject.FindGameObjectWithTag ("object panel");
		ma = GetComponentInChildren<ModifyActions> ();
		togglePanelInactive ();
	}

	public void togglePanel(){
		panel.SetActive (!panel.activeSelf);
	}

	public static void togglePanelActive(){
		//print ("Setting object panel active");
		panel.SetActive (true);
	}

	public static void togglePanelInactive(){
		panel.SetActive (false);
	}
}
