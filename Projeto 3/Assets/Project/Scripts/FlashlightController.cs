using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {

	//Sons da lanterna ligando e desligando
	public AudioClip soundOn, soundOff; 

	//Declaração dos componentes de Luz e AudioSource
	Light flashlight;
	AudioSource fxSource;

	void Awake () {
		
		//Atribuição das declarações de Luz e AudioSource
		flashlight = gameObject.GetComponent<Light> ();
		fxSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {

		//Quando a tecla F é apertada, verifica-se se o componente da luz está ativo
		if (Input.GetKeyDown (KeyCode.F)) {
			if (!flashlight.enabled) {
				flashlight.enabled = true;
				PlaySoundEffect (soundOn);
			} else {
				flashlight.enabled = false;
				PlaySoundEffect (soundOff);
			}
		}
	}

	//Função para tocar os sons da lanterna, passando o som necessário por parametro
	void PlaySoundEffect(AudioClip _soundEffect) {
			fxSource.clip = _soundEffect;
			fxSource.Play ();
	}
}
