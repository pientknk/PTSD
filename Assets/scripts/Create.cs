using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	private GameObject location;
	private float counter = 0;
	public GameObject[] obj;
	public float timeBetweenSpawns = 3.0f;
	private int[] r = new int[10];
	private int i;

	// Use this for initialization
	void Start () {
		location = GameObject.Find ("spawnPoint");
		r [0] = 1;
		r [1] = 0;
		r [2] = 1;
		r [3] = 0;
		r [4] = 1;
		r [5] = 1;
		r [6] = 1;
		r [7] = 0;
		r [8] = 1;
		r [9] = 0;

		i = 0;
	}

	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > timeBetweenSpawns) {
			GameObject spawnedObject;
			spawnedObject = Instantiate (obj[r[i]], location.transform.position, Quaternion.identity) as GameObject;
			counter = 0;
			if (i < r.Length - 1) {
				i++;
			} else {
				i = 0;
			}
		}
	}
}
