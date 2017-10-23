using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosController : MonoBehaviour {

	public AudioClip basementAudio;
	public AudioClip soundtrack;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeSong(AudioClip _clip) {
		audioSource.clip = _clip;
		audioSource.pitch = 1f;
		audioSource.Play ();
	}

	public void ActivateBasementSound() {
		if (audioSource.clip == soundtrack) {
			audioSource.pitch *= 0.99f;
			if (audioSource.pitch < 0.1f) {
				audioSource.Pause ();
				ChangeSong (basementAudio);
			}
		}
	}

	public void DesactivateBasementSound() {
		if (audioSource.clip == basementAudio) {
			audioSource.pitch *= 0.99f;
			if (audioSource.pitch < 0.1f) {
				audioSource.Pause ();
				ChangeSong (soundtrack);
			}
		}
		
	}
}
