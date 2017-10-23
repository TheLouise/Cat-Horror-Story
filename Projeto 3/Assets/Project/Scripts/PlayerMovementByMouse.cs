using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementByMouse : MonoBehaviour {

    Vector3 movement;
    Rigidbody rb;
	Animation anim;
	public LayerMask floorMask;
	//AudioSource fxSource;

	[SerializeField] float speed = 6f;
    float camRayLength = 1000f;

	float horizontal;
	float vertical;

	void Awake () {
		rb = GetComponent<Rigidbody> ();	
		anim = GetComponent<Animation> ();
		//fxSource = GetComponent<AudioSource> ();
	}

	/*void Update(){
		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			if (fxSource.isPlaying == false) {
				fxSource.volume = Random.Range (0.8f, 1f);
				fxSource.pitch = Random.Range (0.8f, 1f);
				fxSource.Play ();
			}
		}
	}*/

	void FixedUpdate () {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turning();
		SetAnimation ();
	}

	void Move (float h, float v) {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed;
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
	}

    void Turning()
    {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(camRay, out hit, camRayLength, floorMask)) {
			Vector3 point = hit.point - transform.position;
			point.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (point);
			rb.MoveRotation (newRotation);
			Debug.DrawRay (camRay.origin, camRay.direction * hit.distance, Color.green);
		}
    }

	void SetAnimation() {
		if (horizontal > 0.01f || horizontal < -0.01f || vertical > 0.01f || vertical < -0.01f) {
				anim.Play ("Walk");
		} else
			anim.Play ("Wait");
	}
}
