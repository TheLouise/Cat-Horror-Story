using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour {

	NavMeshAgent path;
	Transform target;

	void Start () {
		path = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		StartCoroutine (UpdatePath ());
	}

	IEnumerator UpdatePath(){
		float refreshTime = 1;

		while (target != null) {
			Vector3 targetPos = new Vector3 (target.position.x, 0, target.position.z);
			path.SetDestination (targetPos);
			yield return new WaitForSeconds (refreshTime);
		}
	}
}
