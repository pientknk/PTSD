using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {


	public void SaveLevel(){
		LevelController.instance.Save ();
	}

	public void NewGame(){
		SceneManager.LoadScene ("Level 1");
	}
	
	public void LoadLevelSelector(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("LevelSelector");
	}

	public void QuitToMainLevel(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("MainMenu");
	}

    public void RestartCurrentLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void LoadSettings(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("Settings");
	}
}
