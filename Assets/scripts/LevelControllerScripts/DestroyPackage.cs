using UnityEngine;

public class DestroyPackage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "blue item" || col.gameObject.tag == "orange item") {
			LevelController.instance.FailurePackages++;
			LevelController.instance.CurrentMoney -= (int)LevelController.instance.packageWorth / 2;
			Destroy (col.gameObject);
			LevelController.instance.PackagesDestroyed++;
			checkPackageDestructionCount ();
		} else {
			print ("Unknown object colliding with DestroyPackage Script");
			Destroy (col.gameObject);
		}
	}

	private void checkPackageDestructionCount(){
		if (LevelController.instance.summaryCanvas != null) {
			if (LevelController.instance.PackagesDestroyed == LevelController.instance.allPackages.Count) {
				print ("Done with level");
				LevelController.instance.summaryCanvas.SetActive (true);
				LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
			}
		} else {
			print ("Summary canvas is not set");
		}
	}
}
