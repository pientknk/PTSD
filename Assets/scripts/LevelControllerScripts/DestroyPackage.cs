using UnityEngine;

public class DestroyPackage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		LevelController.instance.FailurePackages++;
		LevelController.instance.currentMoney -= (int)LevelController.instance.packageWorth / 2;
		Destroy (col.gameObject);
	}
}
