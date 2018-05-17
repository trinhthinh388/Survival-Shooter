using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10f;
	Vector3 movement;
	Animator animator;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	// Use this for initialization
	void Awake () {
		playerRigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		floorMask = LayerMask.GetMask("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
        
		Moving(h, v);

		Turning();

		Animating(h, v);
        
	}

    void Moving(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
	}

    void Turning()
	{
		
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
			//Debug.DrawRay(transform.position, Input.mousePosition, Color.red, 1);
		}
	}

    void Animating(float h, float v)
	{
		bool isWalking = h != 0 || v != 0;
		animator.SetBool("IsWalking", isWalking);
	}
}
