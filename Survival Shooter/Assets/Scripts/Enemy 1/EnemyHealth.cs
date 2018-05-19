using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    
	public float health;
	public Image healthIMG;
	public bool isDead;
	public AudioClip zombieDead;
	Animator animator;
	AudioSource zombieSource;
	public Light deadLight;
	public ParticleSystem deadParticle;
   
	// Use this for initialization
	void Start()
	{
		health = 100f;
		animator = GetComponent<Animator>();
		healthIMG.fillAmount = health / 100;
		zombieSource = GetComponent<AudioSource>();
		isDead = false;
		deadParticle.Stop();
	}

	// Update is called once per frame
	void Update () {
		healthIMG.fillAmount = health / 100;
	}

	public void takeDamage(float amount)
	{
		if (isDead)
			return;
		health -= amount;
		if(health <= 0)
		{
			StartCoroutine(Dead());
			return;
		}
		else
		{
			zombieSource.Play();
		}
	}

    IEnumerator Dead()
	{
		deadParticle.Play();
		deadLight.enabled = true;
		zombieSource.clip = zombieDead;
		zombieSource.Play();
		isDead = true;
		animator.SetTrigger("PlayerDead");
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
