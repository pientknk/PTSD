using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attached to each spawn point
public class SpawningController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (LevelController.instance.NumPackagesLeft > 0) {
			LevelController.instance.TimeCounter += Time.deltaTime;
			if (LevelController.instance.TimeCounter > LevelController.instance.spawnTime) {
				//instantiate the new packace from allPackages list and set its position to the object this script is attached to
				GameObject package = Instantiate (LevelController.instance.allPackages [LevelController.instance.NumPackagesLeft - 1]);
				package.transform.SetParent (LevelController.instance.theLevelObjects.transform, false);
				package.transform.localPosition = gameObject.transform.localPosition;

				//update the amount of packages left 
				LevelController.instance.NumPackagesLeft--;
				LevelController.instance.TimeCounter = 0;
				//if infinite create is on, loop through all packages again and again
				if (LevelController.instance.NumPackagesLeft == 0 && LevelController.instance.infiniteCreate) {
					LevelController.instance.NumPackagesLeft = LevelController.instance.allPackages.Count;
				}
			}
		}
	}
}
