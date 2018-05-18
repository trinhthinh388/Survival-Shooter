using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float damage = 10f;
	public float timeBetweenAttack = 0.5f;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool isInRange;
	float timer = 0f;
	Animator animator;
	// Use this for initialization
	void Start () {
		enemyHealth = GetComponent<EnemyHealth>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(playerHealth.health > 0 && isInRange && timer >= timeBetweenAttack && !enemyHealth.isDead)
		{
			Attack();
		}
        if(playerHealth.health <= 0)
		{
			animator.SetTrigger("PlayerDead");
		}
		Animating();
	}

    void Attack()
	{
		timer = 0;
		playerHealth.takeDamage(damage);

	}

    void Animating()
	{
		if(isInRange)
			animator.SetBool("InRange", true);
		else
		{
			animator.SetBool("InRange", false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		isInRange = true;
	}
	private void OnTriggerExit(Collider other)
	{
		isInRange = false;
	}
}
