using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	// public 
	public bool infiniteCreate = false;
	public bool autoGenerate = false;
	public GameObject location;
	public GameObject Location{
		get{
			return location;
		}
	}
	public GameObject[] spawnOrder;
	public float secondsBetweenSpawns = 3.0f;
	public GameObject[] allSpawnedObjects;

	//private
	private GameObject canvas;
	private float counter = 0;
	private int i;
	private int numObjects;
	public int NumObjects{
		get{
			return numObjects;
		}
	}

	// Use this for initialization
	void Start () {
		i = 0;
		numObjects = spawnOrder.Length;
		canvas = GameObject.Find ("Canvas");
		AutoGenerate ();
	}

	private void AutoGenerate(){
		if (autoGenerate) {
			for (int z = 0; z < spawnOrder.Length; z++) {
				switch (Random.Range (0, 4)){
				case 0:
					spawnOrder [z] = allSpawnedObjects [0];
					break;
				case 1:
					spawnOrder [z] = allSpawnedObjects [1];
					break;
				case 2:
					spawnOrder [z] = allSpawnedObjects [2];
					break;
				case 3:
					spawnOrder [z] = allSpawnedObjects [3];
					break;
				default:
					print ("Error, inded out of range");
					break;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
			if (i != spawnOrder.Length) {
				counter += Time.deltaTime;
				if (counter > secondsBetweenSpawns) {
					GameObject spawned = Instantiate (spawnOrder [i], location.transform.position, Quaternion.identity) as GameObject;
					spawned.transform.SetParent (canvas.transform);
					Transform clonetrans = spawned.GetComponent<Transform> ();
					// if circle
					if (spawned.GetComponent<CirclePackage> () != null) {
						clonetrans.localScale = new Vector2 (1.85f, 1.85f);
						CircleCollider2D spawnedCollider = spawned.GetComponent<CircleCollider2D> ();
						Vector2 S = spawned.GetComponent<SpriteRenderer> ().sprite.bounds.size;
						spawnedCollider.radius = (S.x / 2);
					}
					// if box
					if (spawned.GetComponent<BoxPackage> () != null) {
						clonetrans.localScale = new Vector2 (2.35f, 2.35f);
						Vector2 S = spawned.GetComponent<SpriteRenderer> ().sprite.bounds.size;
						spawned.GetComponent<BoxCollider2D> ().size = S;
					} 
					numObjects--;
					counter = 0;
					i++;
					if (i == spawnOrder.Length && infiniteCreate) {
						i = 0;
					}
				}
			}
	}
}
