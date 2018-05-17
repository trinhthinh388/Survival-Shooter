using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float smoothSpeed;
	Vector3 offset;

    
	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
		smoothSpeed = 100f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 targetCam = target.position + offset;
		transform.position = Vector3.Lerp(transform.position,targetCam, smoothSpeed * Time.deltaTime);
	}
}
