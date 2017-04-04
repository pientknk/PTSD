using UnityEngine;

public class DestroyPackage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		LevelController.instance.FailurePackages++;
		LevelController.instance.currentMoney -= (int)LevelController.instance.packageWorth / 2;
		Destroy (col.gameObject);
		LevelController.instance.PackagesDestroyed++;
		checkPackageDestructionCount ();

	}

	private void checkPackageDestructionCount(){
		if (LevelController.instance.PackagesDestroyed == LevelController.instance.allPackages.Count) {
			print ("Done with level");
			LevelController.instance.summaryCanvas.SetActive (true);
			LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
		}
	}
}
