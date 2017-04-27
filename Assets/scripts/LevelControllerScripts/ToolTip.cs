using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	private static ToolTip instance;
	public static ToolTip Instance {
		get { 
			if (instance == null) {
				instance = GameObject.FindObjectOfType<ToolTip>();
			}
			return instance;
		}
	}

	public bool IsActive{
		get{ return gameObject.activeSelf; }
	}

	public Text tooltipText;

	void Awake(){
		instance = this;
		HideTooltip ();
	}

	public void ShowTooltip(string text, Vector3 pos){
		if (tooltipText.text != text) {
			tooltipText.text = text;
		}
		transform.localPosition = pos;
		gameObject.SetActive (true);
	}

	public void HideTooltip(){
		gameObject.SetActive (false);
	}

}
