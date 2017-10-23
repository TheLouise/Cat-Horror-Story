using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysController : MonoBehaviour {

	public int index = -1;

	AudioSource fxSource;

	void Start() {
		fxSource = GetComponent<AudioSource> ();
	}

	public void PickUpKey() {
		fxSource.Play ();
		Destroy (gameObject, 0.5f);
		DisplayInventoryController display = GameObject.Find ("InventoryPanel").GetComponent<DisplayInventoryController> ();
		display.DisplayOnInventory (this.index);

		DialoguesController msgsController = GameObject.Find ("DialoguesController").GetComponent<DialoguesController> ();

		if (this.index == 0 || this.index == 3 || this.index == 4 || this.index == 6) {
			msgsController.DisplayMessage (10);
		} else if (this.index == 1) {
			msgsController.DisplayMessage (13);
		} else if (this.index == 2) {
			msgsController.DisplayMessage (11);
		} else if (this.index == 5) {
			msgsController.DisplayMessage (12);
		} else if (this.index == 7) {
			msgsController.DisplayMessage (14);
		}
	}
}
