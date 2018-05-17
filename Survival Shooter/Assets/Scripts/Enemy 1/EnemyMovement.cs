using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Awake () {
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerHealth.health <= 0)
		{
			nav.SetDestination(transform.position);
			return;
		}
		nav.SetDestination(player.position);
	}
}
