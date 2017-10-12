using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorsController : MonoBehaviour {

	public AudioClip fxOpen, fxClose;
	public int index = -1;

	BoxCollider col;
	Animator anim;
	AudioSource fxSource;
	bool canOpen;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fxSource = GetComponent<AudioSource> ();
		col = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canOpen == true) {
			anim.SetBool ("open", true);
			col.enabled = false;
		}

		if (canOpen == false) {
			anim.SetBool ("open", false);
			//col.enabled = true;
		}
	}

	void PlaySoundEffect(AudioClip _soundEffect) {
		fxSource.clip = _soundEffect;
		fxSource.Play ();
	}

	/*public void ChangeDoorState() {
		canOpen = !canOpen;
		if (canOpen == true) {
			PlaySoundEffect (fxOpen);
		} else if (canOpen == false) {
			PlaySoundEffect (fxClose);
		}
	}*/

	public void OpenDoors(){
		canOpen = true;
		PlaySoundEffect (fxOpen);
		DisplayInventoryController display = GameObject.Find ("InventoryPanel").GetComponent<DisplayInventoryController> ();
		display.DeleteOnInventory (this.index);
	}
}
