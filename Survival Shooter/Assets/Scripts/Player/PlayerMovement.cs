using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

	public class PlayerMovement : MonoBehaviour
	{
		public float speed = 6f;            // The speed that the player will move at.


		Vector3 movement;                   // The vector to store the direction of the player's movement.
		Animator anim;                      // Reference to the animator component.
		Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
		int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
		float camRayLength = 100f;

		void Awake()
		{
			// Create a layer mask for the floor layer.
			floorMask = LayerMask.GetMask("Floor");

			// Set up references.
			anim = GetComponent<Animator>();
			playerRigidbody = GetComponent<Rigidbody>();
		}

		void FixedUpdate()
		{
			float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
			float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

			Move(h, v);

			Turning();

			Animating(h, v);

		}

		void Move(float h, float v)
		{
			movement.Set(h, 0f, v);
			movement = movement.normalized * speed * Time.deltaTime;
			playerRigidbody.MovePosition(transform.position + movement);
		}

		void Turning()
		{
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit floorHit;
			if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
			{

				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;
				Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
				playerRigidbody.MoveRotation(newRotatation);
			}
		}

		void Animating(float h, float v)
		{
			bool walking = h != 0f || v != 0f;
			anim.SetBool("IsWalking", walking);
		}
	}

