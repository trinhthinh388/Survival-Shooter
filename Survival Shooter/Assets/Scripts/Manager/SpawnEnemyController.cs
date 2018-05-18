using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyController : MonoBehaviour
{

	public Transform SpawnPoint;
	public GameObject enemyPreFabs;
	public float maxWave = 2f;
	float WaveIndex = 0f;
	// Use this for initialization
	void Start()
	{
		Instantiate(enemyPreFabs, SpawnPoint.position, SpawnPoint.rotation);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

   
}
