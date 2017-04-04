using UnityEngine;
using UnityEngine.UI;

public class TextChangeController : MonoBehaviour {

	private Text label;
	private int initialValue;
	private int finalValue;
	private float duration = 150.0f;
	private float timeElapsed;
	private bool addedDif = false;

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
			if (!addedDif) {
				float valDif = Mathf.Abs (initialValue - finalValue);
				duration += valDif;
				addedDif = true;
			}
			//print ("Valdif: " + valDif + " time/durartion: " + (timeElapsed / duration));
			float value = Mathf.Lerp (initialValue, finalValue, (timeElapsed / duration));
			label.text = value.ToString ("####");
		}
	}
}
