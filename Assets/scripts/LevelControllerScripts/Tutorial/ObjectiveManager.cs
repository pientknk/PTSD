using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

	public List<Objective> objectives;
	private int objectiveIndex = 0;
	
	// Update is called once per frame
	void Update () {
		//run objective

		//load next objective if completed
		if (objectives [objectiveIndex].IsCompleted ()) {
			objectiveIndex++;
			if (objectiveIndex == objectives.Count) {
				Destroy (this);
			}
		}

	}
}
