using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeShooting : MonoBehaviour {

	public float damagePerBullet;
	public float TimeBetweenBullet;
	public float gunRange;
	public Light faceLight;
	AudioSource gunShot;
	float timer;
	Ray gunRay = new Ray();
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer shootLine;
	Light gunLight;
	float effectsDisplayTime = 0.2f;



	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask("Shootable");
		shootLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();
		gunShot = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetMouseButton(0) && timer >= TimeBetweenBullet && Time.timeScale != 0)
		{         
			shoot();
		}
        if(timer >= TimeBetweenBullet * effectsDisplayTime)
		{
			disableEffects();
		}
	}

    void shoot()
	{
		timer = 0;
		gunShot.Stop();
		gunShot.Play();
		faceLight.enabled = true;
		gunLight.enabled = true;
		shootLine.enabled = true;
        shootLine.SetPosition(0, transform.position);

        gunRay.origin = transform.position;
        gunRay.direction = transform.forward;      

		if (Physics.Raycast(gunRay, out shootHit, gunRange, shootableMask))
		{
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth.health > 0)
			    enemyHealth.takeDamage(damagePerBullet);
			shootLine.SetPosition(1, shootHit.point);
		}
		else
		{
			shootLine.SetPosition(1, gunRay.origin + gunRay.direction * gunRange);
		}
	}

    void disableEffects()
	{
		gunLight.enabled = false;
		shootLine.enabled = false;
		faceLight.enabled = false;

	}
}
