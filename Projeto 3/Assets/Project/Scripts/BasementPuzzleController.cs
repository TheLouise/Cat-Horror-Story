using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementPuzzleController : MonoBehaviour {

	public GameObject key;
	public SimpleDoorController door;

	GameObject blocker;
	GameObject trigger;

	//bool active = false;

	// Use this for initialization
	void Start () {
		blocker = GameObject.Find ("BBlocker");
		trigger = GameObject.Find ("BTrigger");
		blocker.SetActive (false);		
		key.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ActivePuzzle(){
		//active = true;
		blocker.SetActive (true);
		door.CloseDoor ();

		//AudiosController audioC = GameObject.Find ("AudiosController").GetComponent<AudiosController> ();
		DialoguesController dialogue = GameObject.Find ("DialoguesController").GetComponent<DialoguesController> ();

		dialogue.DisplayMessage (8);
		//audioC.ActivateBasementSound ();

		Invoke ("DeactivatePuzzle", 10f);
	}

	void DeactivatePuzzle() {
		//active = false;
		blocker.SetActive (false);
		key.SetActive (true);
		door.OpenDoor ();

		//AudiosController audioC = GameObject.Find ("AudiosController").GetComponent<AudiosController> ();
		DialoguesController dialogue = GameObject.Find ("DialoguesController").GetComponent<DialoguesController> ();

		dialogue.DisplayMessage (9);
		//audioC.DesactivateBasementSound ();
	}
}
