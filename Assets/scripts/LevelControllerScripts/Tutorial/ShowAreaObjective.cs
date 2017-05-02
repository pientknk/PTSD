using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAreaObjective : Objective {

	public Vector2 arrowLocation = new Vector2(0.0f, 0.0f);
	public Vector2 dialogueLocation = new Vector2(0.0f, 0.0f);
	public string info;
	public string direction;
	private bool completed = false;

	public override string GetInfo(){
		return info;
	}

	public override bool IsCompleted (){
		return completed;
	}

	public override void RunObjective(){

	}

	public void Completed(){
		completed = true;
	}
}
