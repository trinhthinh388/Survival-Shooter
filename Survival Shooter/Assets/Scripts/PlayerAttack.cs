using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public float DamagePerBullets = 20f;
	public float TimeBetweenShot = 0.15f;
	public float gunLength = 100f;
	public ParticleSystem shotPar;
	public Light gunLight;
	public Light shotLight;
	float effectsDisplayTime = 0.2f ;
	LineRenderer lineShot;
	float timer;
	Ray shotRay;
	int shotMask;
	RaycastHit shotHit;


	// Use this for initialization
	void Awake () {
		shotMask = LayerMask.GetMask("Shootable");
		lineShot = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(Input.GetButton("Fire1") && timer >= TimeBetweenShot)
		{
			Shoot();
		}
		if (timer >= TimeBetweenShot * effectsDisplayTime)
        {
            DisableEffects();
        }
	}

    void Shoot()
	{
		timer = 0;

		shotLight.enabled = true;

		lineShot.enabled = true;
		gunLight.enabled = true;
		lineShot.SetPosition(0, transform.position);

		shotPar.Stop();
		shotPar.Play();


		shotRay.origin = transform.position;
		shotRay.direction = transform.forward;

        if(Physics.Raycast(shotRay, out shotHit, gunLength, shotMask))
		{

		}
		else
		{
			lineShot.SetPosition(1, shotRay.origin + shotRay.direction * gunLength);
		}
	}

	void DisableEffects()
	{
		lineShot.enabled = false;
		gunLight.enabled = false;
		shotLight.enabled = false;
	}
}
