using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {


	public void SaveLevel(){
		LevelController.instance.Save ();
	}
	
	public void QuitLevel(){
		SceneManager.LoadScene ("LevelSelector");
	}

	public void QuitToMainLevel(){
		SceneManager.LoadScene ("MainMenu");
	}
}
