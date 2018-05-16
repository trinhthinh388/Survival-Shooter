using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public int damagePerShot;
	public float timeBetweenBullets;
	public float range;
	public Light faceLight;

	float timer;
	Ray gunRay = new Ray();
	RaycastHit shootHit;
	LayerMask shootableMask;
	//ParticleSystem gunParticles;
	LineRenderer gunLine;
	//AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;

	private void Awake()
	{
		shootableMask = LayerMask.GetMask("Shootable");

		//gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
	}

	private void Update()
	{

		timer += Time.deltaTime;
		if(Input.GetMouseButton(0) && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			Shoot();
		}

        if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			disableEffects();
		}
	}

    void Shoot()
	{
		timer = 0;

		//gunAudio.Play();
        
		faceLight.enabled = true;
		gunLight.enabled = true;

		//gunParticles.Stop();
		//gunParticles.Play();

		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		gunRay.origin = transform.position;
		gunRay.direction = transform.forward;

		if (Physics.Raycast(gunRay, out shootHit, range, shootableMask))
		{
			gunLine.SetPosition(1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition(1, gunRay.origin + gunRay.direction * range);
		}

	}

    void disableEffects()
	{
		gunLine.enabled = false;
		faceLight.enabled = false;
		gunLight.enabled = false;
	}
}
