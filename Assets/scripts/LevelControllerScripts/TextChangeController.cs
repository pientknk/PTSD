using UnityEngine;
using UnityEngine.UI;

public class TextChangeController : MonoBehaviour {

	private Text label;
	private int initialValue;
	private int finalValue;
	private float duration = 150.0f;
	private float timeElapsed;

	public void Create(Text textLabel, int initial, int final){
		label = textLabel;
		initialValue = initial;
		finalValue = final;
		duration += Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.realtimeSinceStartup;
		if (timeElapsed > duration) {
			label.text = finalValue.ToString ();
			Destroy (this);
		} else {
			float value = Mathf.Lerp (initialValue, finalValue, (timeElapsed / duration));
			label.text = value.ToString ("####");
		}
	}
}
