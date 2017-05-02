using UnityEngine;

public abstract class Objective: MonoBehaviour {

	abstract public string GetInfo ();
	abstract public bool IsCompleted ();
	abstract public void RunObjective ();

}
