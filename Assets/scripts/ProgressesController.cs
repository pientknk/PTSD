﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressesController : MonoBehaviour {

	private Text moneyLabel;
	private float currentMoney;
	public float CurrentMoney{
		set{ currentMoney = value; }
	}
	private float moneyNeeded;
	private Text packageLabel;
	private int currentPackages;
	private int packagesNeeded;

	private GameObject moneyProgressBar;
	private Image moneyBarImage;
	private Color originalColor;
	private GameObject packageProgressBar;
	private Image packageBarImage;

	private MoneyTracker mt;
	private DeliveringPackagesCounter dpc;

	private bool completedMoney = false;
	private bool completedPackages = false;

	// Use this for initialization
	void Start () {
		dpc = GameObject.FindGameObjectWithTag ("successfailure").GetComponent<DeliveringPackagesCounter>();
		mt = GameObject.FindGameObjectWithTag ("Money").GetComponent<MoneyTracker> ();
		currentMoney = mt.Money;
		moneyNeeded = 1000.0f;
		currentPackages = dpc.SuccessCount;
		packagesNeeded = 20;
		moneyProgressBar = GameObject.Find ("Money Progress Bar");
		moneyLabel = moneyProgressBar.transform.GetChild (3).GetComponent<Text> ();
		packageProgressBar = GameObject.Find ("Package Progress Bar");
		packageLabel = packageProgressBar.transform.GetChild (3).GetComponent<Text> ();

		packageBarImage = packageProgressBar.transform.GetChild (2).GetComponent<Image> ();
		moneyBarImage = moneyProgressBar.transform.GetChild (2).GetComponent<Image> ();
		originalColor = packageBarImage.color;
	}
		
	public void UpdatePackageProgress(){
		currentPackages = dpc.SuccessCount;
		if (currentPackages >= packagesNeeded) {
			currentPackages = packagesNeeded;
			packageBarImage.color = Color.green;
			completedPackages = true;
		}
		string packageCount = currentPackages + "/" + packagesNeeded;
		packageLabel.text = packageCount;
		float current = currentPackages;
		float max = packagesNeeded;
		packageBarImage.fillAmount = current / max;
	}
		
	public void updateMoneyProgress(){
		string moneyCount;
		currentMoney = mt.Money;
		if (currentMoney < 0) {
			moneyCount = "0/" + moneyNeeded;
			moneyBarImage.color = originalColor;
			moneyBarImage.fillAmount = 0;
			completedMoney = false;
		} else if (currentMoney > moneyNeeded) {
			moneyCount = moneyNeeded + "/" + moneyNeeded;
			moneyBarImage.color = Color.green;
			moneyBarImage.fillAmount = moneyNeeded;
			completedMoney = true;
		} else{
			moneyCount = currentMoney + "/" + moneyNeeded;
			moneyBarImage.fillAmount = currentMoney / moneyNeeded;
			moneyBarImage.color = originalColor;
			completedMoney = false;
		}
		moneyLabel.text = moneyCount;
	}
}