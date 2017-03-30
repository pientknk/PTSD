using UnityEngine;

public class DestroyPackage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		LevelController.instance.failurePackages++;
		LevelController.instance.currentMoney -= (int)LevelController.instance.packageWorth / 2;
		Destroy (col.gameObject);
	}
}
