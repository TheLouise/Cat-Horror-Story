using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorController : MonoBehaviour {

	public AudioClip fxOpen, fxClose;

	public int index = -1;
	public float openAngle = -90f;

	AudioSource fxSource;

	float smooth = 2f;
	float closeAngle = 0f;
	bool isOpen = false;
	//bool canOpen = false;

	// Use this for initialization
	void Start () {
		fxSource = GetComponent<AudioSource> ();		
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen == true) {
			var angle = Quaternion.Euler (0, openAngle, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, angle, Time.deltaTime * smooth);
		}

		if (isOpen == false) {
			var angle1 = Quaternion.Euler (0, closeAngle, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, angle1, Time.deltaTime * smooth);
		}
	}

	void PlaySoundEffect(AudioClip _soundEffect) {
		fxSource.clip = _soundEffect;
		fxSource.Play ();
	}

	public void OpenDoor(){
		isOpen = true;
		PlaySoundEffect (fxOpen);

		DisplayInventoryController display = GameObject.Find ("InventoryPanel").GetComponent<DisplayInventoryController> ();
		display.DeleteOnInventory (this.index);
	}

	public void CloseDoor(){
		isOpen = false;
		PlaySoundEffect (fxClose);
	}
}
