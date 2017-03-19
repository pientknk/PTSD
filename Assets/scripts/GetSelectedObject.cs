using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSelectedObject : MonoBehaviour {

	private ModifyActions ma;
	private static GameObject clickedObject;
	public GameObject ClickedObject{
		get{ return clickedObject; }
	}
	private RaycastHit2D hit;
	private string nameObject;
	public string NameObject{
		get{ return nameObject; }
	}
	// Use this for initialization
	void Start () {
		nameObject = "None";
		ma = GameObject.FindGameObjectWithTag ("Modifiers").GetComponent<ModifyActions> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			hit = Physics2D.Raycast (new Vector2 (mousePos.x, mousePos.y), Vector2.zero);
				
			if (hit.collider != null) {
				clickedObject = hit.transform.gameObject;
				ma.SelectedObject = null;
				switch (clickedObject.tag) {
				case "Conveyor":
					nameObject = "Conveyor";
					ma.SelectedObject = clickedObject;
					break;
				case "Fan":
					nameObject = "Fan";
					ma.SelectedObject = clickedObject;
					break;
				case "Slide":
					nameObject = "Slide";
					ma.SelectedObject = clickedObject;
					break;
				case "Trampoline":
					nameObject = "Trampoline";
					ma.SelectedObject = clickedObject;
					break;
				default:
					nameObject = "None";
					break;
				}
			} else {
				ma.SelectedObject = null;
				print ("Didn't hit a collider");
				nameObject = "None";
			}
				
			
				
		}
	}
}
