using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	private GameObject location;
	private float counter = 0;
	public GameObject obj;
	public float timeBetweenSpawns = 3.0f;

	// Use this for initialization
	void Start () {
		location = GameObject.Find ("spawnPoint");	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > timeBetweenSpawns) {
			GameObject spawnedObject;
			spawnedObject = Instantiate (obj, location.transform.position, Quaternion.identity) as GameObject;
			counter = 0;
		}
	}
}
