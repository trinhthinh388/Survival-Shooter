using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;

	// Use this for initialization
	void Awake () {
		enemyHealth = GetComponent<EnemyHealth>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerHealth.health <= 0 || enemyHealth.isDead)
		{
			Idle();
			return;
		}
		nav.SetDestination(player.position);
	}

    public void Idle()
	{
		nav.SetDestination(transform.position);
	}
}
