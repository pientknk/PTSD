using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attached to each 
public class SpawningController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (LevelController.instance.numPackagesLeft > 0) {
			LevelController.instance.timeCounter += Time.deltaTime;
			if (LevelController.instance.timeCounter > LevelController.instance.spawnTime) {
				//instantiate the new packace from allPackages list and set its position to the object this script is attached to
				GameObject package = Instantiate (LevelController.instance.allPackages [LevelController.instance.numPackagesLeft - 1]);
				package.transform.SetParent (LevelController.instance.theLevelObjects.transform, false);
				package.transform.localPosition = gameObject.transform.localPosition;
//				//if its a circle
//				if (package.GetComponent<CirclePackage> () != null) {
//					//make its collider match the size of the sprite in game
//					Vector2 s = package.GetComponent<SpriteRenderer> ().sprite.bounds.size;
//					package.GetComponent<CircleCollider2D> ().radius = (s.x / 2);
//				}
//				//if its a box
//				if (package.GetComponent<BoxPackage> () != null) {
//					RectTransform rectT = package.GetComponent<RectTransform> ();
//					//make its collider match the size of the sprite in game
//					Vector2 s = package.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size;
//					package.GetComponent<BoxCollider2D> ().size = s;
//				}
				//update the amount of packages left 
				LevelController.instance.numPackagesLeft--;
				LevelController.instance.timeCounter = 0;
				//if infinite create is on, loop through all packages again and again
				if (LevelController.instance.numPackagesLeft == 0 && LevelController.instance.infiniteCreate) {
					LevelController.instance.numPackagesLeft = LevelController.instance.allPackages.Count;
				}
			}
		}
	}

	public void AutoGenerate(){
		if (LevelController.instance.autoPickPackages) {
			for (int z = 0; z < LevelController.instance.allPackages.Count; z++) {
				//pick a random package from all the possible packages on the level
				int random = Random.Range (0, LevelController.instance.packageTypes.Count);
				LevelController.instance.allPackages [z] = LevelController.instance.packageTypes [random];
			}
		}
	}
}
