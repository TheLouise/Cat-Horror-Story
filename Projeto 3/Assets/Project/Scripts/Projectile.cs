using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField]
	private float speed = 10f;

	private Vector3 forward, right; 

	void Start(){
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize (forward);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (forward * Time.deltaTime * speed);
	}

	public void SetSpeed(float _speed){
		speed = _speed;
	}
}
