using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsController : MonoBehaviour {

	public float interactDist;
	public LayerMask doorLayer;
	public BasementPuzzleController basementPuzzle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, interactDist)) {
				Debug.Log (hit.collider.gameObject);

				// ------- DOORS ------- // 
				if (hit.collider.CompareTag ("SimpleDoors")) {
					SimpleDoorController doorController = hit.collider.transform.GetComponent<SimpleDoorController> ();

					if (doorController == null)
						return;
					
					if (InventoryController.keys [doorController.index] == false) {
						DialoguesController msgsController = GameObject.Find ("DialoguesController").GetComponent<DialoguesController> ();
						msgsController.DisplayMessage (doorController.index);
					}

					if (InventoryController.keys [doorController.index] == true) {
						doorController.OpenDoor ();
					}

					Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.blue);
				} else 

					if (hit.collider.CompareTag ("DoubleDoors")) {
						DoubleDoorsController doorsController = hit.collider.transform.GetComponent<DoubleDoorsController> ();

					if (doorsController == null)
						return;
						
					if (InventoryController.keys [doorsController.index] == false) {
						DialoguesController msgsController = GameObject.Find ("DialoguesController").GetComponent<DialoguesController> ();
						msgsController.DisplayMessage (doorsController.index);
					}

					if (InventoryController.keys [doorsController.index] == true) {
							doorsController.OpenDoors ();
					}

					Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.blue);
					
				}

				// ------- KEYS ------- // 
				if (hit.collider.CompareTag ("Keys")) {
					InventoryController.keys[hit.collider.GetComponent<KeysController>().index] = true;
					hit.collider.GetComponent<KeysController> ().PickUpKey ();
				}

				if (hit.collider.name == "Switch") {
					hit.collider.GetComponent<SwitchController> ().SendLightMessage ();
				}
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "BTrigger") {
			basementPuzzle.ActivePuzzle ();
			Destroy (col.gameObject);
		}

		if (col.gameObject.name == "GameOverT") {
			SceneController sceneController = GameObject.Find ("SceneController").GetComponent<SceneController> ();
			sceneController.GameOver ();
			Destroy (col.gameObject);
		}
	}
}
