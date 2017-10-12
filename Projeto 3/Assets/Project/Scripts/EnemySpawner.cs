using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject ghost;
	public Transform[] spawnPoints;

	[SerializeField]
	float cooldown = 3f;

	void Start () {
		InvokeRepeating ("Spawn", cooldown, cooldown);
	}

	void Spawn() {
		
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (ghost, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
