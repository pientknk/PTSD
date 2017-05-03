using UnityEngine;

public class DestroyPackage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "blue item" || col.gameObject.tag == "orange item") {
			LevelController.instance.FailurePackages++;
			LevelController.instance.CurrentMoney -= (int)LevelController.instance.packageWorth / 2;
			Destroy (col.gameObject);
			LevelController.instance.NumPackagesLeft--;
			checkPackageDestructionCount ();
		} else {
			Destroy (col.gameObject);
		}
	}

	private void checkPackageDestructionCount(){
		if (LevelController.instance.summaryCanvas != null) {
			if (LevelController.instance.NumPackagesLeft == 0) {
				LevelController.instance.summaryCanvas.SetActive (true);
				Time.timeScale = LevelController.instance.PauseGameSpeed;
				LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
			}
		} else {
			print ("Summary canvas is not set");
		}
	}
}
