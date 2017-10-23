using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

	AudioSource fx;

	// Use this for initialization
	void Start () {
		fx = GetComponent<AudioSource> ();
	}

	public void SendLightMessage() {
			DialoguesController message = GameObject.Find ("DialoguesController").GetComponent<DialoguesController> ();
			message.DisplayMessage (15);
			fx.Play ();
	}
}
