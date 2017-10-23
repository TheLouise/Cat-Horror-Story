using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	Ray shootRay;
	RaycastHit shootHit;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;

	[SerializeField]
	int damage = 20;
	[SerializeField]
	float range = 100f;
	[SerializeField]
	float cooldown = 0.15f;

	int shootableMask;
	float timer;
	float effectsTimer = 0.2f;

	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");

		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}

	void Update () {
		timer += Time.deltaTime;

		if (Input.GetButtonDown ("Fire1") && timer >= cooldown) {
			Shoot ();
		}

		if (timer >= cooldown * effectsTimer) {
			DisableEffects ();
		}
	}

	public void DisableEffects(){
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot() {
		timer = 0f;

		gunAudio.Play ();
		gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			GhostHealth ghostHP = shootHit.collider.GetComponent<GhostHealth> ();

			if (ghostHP != null) {
				ghostHP.TakeDamage (damage, shootHit.point);
			}

			gunLine.SetPosition (1, shootHit.point);
		} else {
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}
