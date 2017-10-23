using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour {

	[SerializeField]
	int health = 100;

	int currentHealth;
	bool isDead;

	void Awake () {
		currentHealth = health;
	}

	public void TakeDamage(int amount, Vector3 hitPoint) {
		if (isDead)
			return;

		currentHealth -= amount;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death() {
		isDead = true;
		Destroy (gameObject, 0.5f);
	}
}
