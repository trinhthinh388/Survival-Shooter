using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour {

	Transform player;
    NavMeshAgent nav;
    EnemyHealth enemyHealth;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyHealth.currentHealth <= 0)
            nav.enabled = false;
        nav.SetDestination(player.position);
	}
}
