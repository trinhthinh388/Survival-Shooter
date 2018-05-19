using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public float smoothSpeed = 100f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = -player.position + transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPos = player.position + offset;
		transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
	}
}
