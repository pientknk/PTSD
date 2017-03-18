using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelController : MonoBehaviour{

	private GameObject objectPanel;
	// Use this for initialization
	void Start () {
		RectTransform usableTransform = gameObject.GetComponent<RectTransform> ();
		float height = usableTransform.rect.height / 2;
		float width = usableTransform.rect.width / 2;
		GameObject panel = GameObject.FindGameObjectWithTag ("Canvas");
		objectPanel = (GameObject)Instantiate(Resources.Load("Prefabs/UI/Object Panel v2"), 
								new Vector3(transform.position.x + width + 4, transform.position.y - height,
								transform.position.z), Quaternion.identity, panel.transform);
		if (objectPanel != null) {
			// set panels transform to right position and set inactive initially
			RectTransform objectRect = objectPanel.GetComponent<RectTransform> ();
			float objHeight = objectRect.rect.height / 2;
			Vector3 objVector = new Vector3 (objectPanel.transform.position.x, 
				objectPanel.transform.position.y - objHeight, 
				objectPanel.transform.position.z);
			objectPanel.transform.position = objVector;
			objectPanel.SetActive (false);

		} else {
			print ("Couldn't load object in ObjectPanelController.cs from specified directory");
		}

	}

	public void togglePanel(){
		if (objectPanel != null) {
			objectPanel.SetActive (!objectPanel.activeSelf);
		} else {
			print ("Can't change active state of a null object in ObjectPanelController.cs");
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
