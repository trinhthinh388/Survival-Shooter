using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public static int EnemyAlive = 0;
        public int MaxEnemyAlive = 100;
        public Transform[] spawnPoint;
        public GameObject enemyPreFabs;
        public float spawnTime = 3f;

        void Start()
        {
            if (EnemyAlive > MaxEnemyAlive)
                return;
            InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
        }

        void SpawnEnemy()
        {
            for (int i = 0; i < spawnPoint.Length; i++ )
                Instantiate(enemyPreFabs, spawnPoint[i].position, spawnPoint[i].rotation);
        }
    }
}