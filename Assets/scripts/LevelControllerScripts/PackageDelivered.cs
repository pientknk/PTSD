using UnityEngine;

public class PackageDelivered : MonoBehaviour {

	public bool scoreBlue = false;
	public bool scoreOrange = false;

	/// <summary>
	/// Raises the collision enter2d event to check what kind of package hits it.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col){
		PackageController pc = col.gameObject.GetComponent<PackageController> ();
		string tag = col.gameObject.tag;
		if (tag == "blue item") {
			if (scoreBlue) {
				LevelController.instance.SuccessfulPackages++;
				float reducedMoney = pc.RegularHealth * (pc.CurrentHealth / pc.RegularHealth);
				int intReducedMoney = (int)reducedMoney;
				LevelController.instance.CurrentMoney += intReducedMoney;
				Destroy (col.gameObject);
				LevelController.instance.PackagesDestroyed++;
				checkPackageDestructionCount ();
			} else {
				LevelController.instance.FailurePackages++;
				LevelController.instance.CurrentMoney -= (int)LevelController.instance.packageWorth / 2;
				Destroy (col.gameObject);
				LevelController.instance.PackagesDestroyed++;
				checkPackageDestructionCount ();
			}
		} else if (tag == "orange item") {
			if (scoreOrange) {
				LevelController.instance.SuccessfulPackages++;
				float reducedMoney = pc.RegularHealth * (pc.CurrentHealth / pc.RegularHealth);
				int intReducedMoney = (int)reducedMoney;
				LevelController.instance.CurrentMoney += intReducedMoney;
				Destroy (col.gameObject);
				LevelController.instance.PackagesDestroyed++;
				checkPackageDestructionCount ();
			} else {
				LevelController.instance.FailurePackages++;
				LevelController.instance.CurrentMoney -= (int)LevelController.instance.packageWorth / 2;
				Destroy (col.gameObject);
				LevelController.instance.PackagesDestroyed++;
				checkPackageDestructionCount ();
			}
		} else {
			print ("Unknown object colliding with PackageDelivered Script");
			Destroy (col.gameObject);
		}
	}

	private void checkPackageDestructionCount(){
		if (LevelController.instance.PackagesDestroyed == LevelController.instance.allPackages.Count) {
			print ("Done with level");
			LevelController.instance.summaryCanvas.SetActive (true);
			LevelController.instance.canvas.GetComponent<CanvasGroup> ().interactable = false;
		}
	}
}
