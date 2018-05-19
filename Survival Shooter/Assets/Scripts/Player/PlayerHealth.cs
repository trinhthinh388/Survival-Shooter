using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float health = 100;
    public Image healthIMG;
	Animator animator;
	public AudioSource playerSource;
	public AudioClip playerDead;
	PlayerMovement playerMovement;
	bool isDead = false;
    // Use this for initialization
    void Start()
    {
		playerMovement = GetComponent<PlayerMovement>();
		animator = GetComponent<Animator>();
		healthIMG.fillAmount = health/100;
    }

    // Update is called once per frame
    void Update()
    {
        healthIMG.fillAmount = health/100;
    }

    public void takeDamage(float amount)
	{
		if(health > 0)
		{
			playerSource.Play();
			health -= amount;
		}
        if(health <= 0)
		{
			Dead();
		}
	}

	void Dead()
	{
		isDead = true;
		playerSource.clip = playerDead;
		playerSource.Play();
		playerMovement.enabled = false;
		animator.SetTrigger("Dead");
	}
}
