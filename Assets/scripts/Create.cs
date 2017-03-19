using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	private static GameObject location;
	public GameObject Location{
		get{
			return location;
		}
	}
	private float counter = 0;
	public GameObject[] spawnOrder;
	private int numObjects;
	public int NumObjects{
		get{
			return numObjects;
		}
	}
	public float secondsBetweenSpawns = 3.0f;
	private int i;

	// Use this for initialization
	void Start () {
		location = GameObject.Find ("Spawn Point");
		i = 0;
		numObjects = spawnOrder.Length;
	}

	// Update is called once per frame
	void Update () {
		if (i != spawnOrder.Length) {
			counter += Time.deltaTime;
			if (counter > secondsBetweenSpawns) {
				GameObject spawned = Instantiate (spawnOrder[i], location.transform.position, Quaternion.identity) as GameObject;
				Transform clonetrans = spawned.GetComponent<Transform> ();
				// if circle
				if (spawned.GetComponent<CirclePackage> () != null) {
					clonetrans.localScale = new Vector2 (1.85f, 1.85f);
					CircleCollider2D spawnedCollider = spawned.GetComponent<CircleCollider2D> ();
					Vector2 S = spawned.GetComponent<SpriteRenderer>().sprite.bounds.size;
					spawnedCollider.radius = (S.x / 2);
				}
				// if box
				if (spawned.GetComponent<BoxPackage>() != null) {
					clonetrans.localScale = new Vector2 (2.35f, 2.35f);
					Vector2 S = spawned.GetComponent<SpriteRenderer>().sprite.bounds.size;
					spawned.GetComponent<BoxCollider2D>().size = S;
				} 
				numObjects--;
				counter = 0;
				i++;
			}
		}
	}
}
