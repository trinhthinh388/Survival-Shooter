using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    
    public float damagePerShot = 20f;
    public float timeBetweenShot = 1f;
    PlayerHealth playerHealth;
    EnemyMovement enemyMovement;
    Animator animator;
    float timer = 0f;
    bool isInRange;
	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (isInRange && timer >= timeBetweenShot)
            Damage();
        Animating();
	}

    void Damage()
    {
        timer = 0;

        playerHealth.TakeDamage(damagePerShot);
    }

    void Animating()
    {
        if(playerHealth.currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            enemyMovement.enabled = false;
            return;
        }
        animator.SetBool("Attacking", isInRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isInRange = false;
        }
    }
}
