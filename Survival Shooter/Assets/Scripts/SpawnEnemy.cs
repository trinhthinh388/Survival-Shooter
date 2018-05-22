using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    Transform spawnPoint;
    public GameObject enemyPreFabs;
    public float spawnTime = 3f;

    int spawnNumber = 0;
    PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
        spawnPoint = GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if(spawnNumber < 5)
            InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0)
            return;

        Instantiate(enemyPreFabs, spawnPoint.position, spawnPoint.rotation);
        spawnNumber++;
    }
}
