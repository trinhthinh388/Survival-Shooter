using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	Vector3 movement;
	Ray camRay;
	int floorMask;
	float camLength = 100f;
	Rigidbody playerRigid;
	Animator anim;
	// Use this for initialization
	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		playerRigid = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move(h, v);

		Turn();

		Animating(h, v);
	}

    void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigid.MovePosition(transform.position + movement);

	}

    void Turn()
	{
		camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
        if(Physics.Raycast(camRay, out floorHit, camLength, floorMask))
		{
			Vector3 offset = floorHit.point - transform.position;
			Quaternion rotation = Quaternion.LookRotation(offset);
			playerRigid.MoveRotation(rotation);
		}
	}

    void Animating(float h, float v)
	{
		bool walk = h != 0 || v != 0;
		anim.SetBool("IsWalking", walk);
	}
}
