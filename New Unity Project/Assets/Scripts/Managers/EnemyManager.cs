using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public static int EnemyAlive = 0;
        public Wave[] waves;
        public Transform spawnPoint;
        public float TimeBetweenWaves = 5f;
        private float countdown = 2f;
        private int waveIndex = 0;

        void Update()
        {
            if (EnemyAlive > 0)
                return;
            if(countdown <= 0)
            {
                StartCoroutine(SpawnWave());
                countdown = TimeBetweenWaves;
                return;
            }
            countdown -= Time.deltaTime;

        }
        IEnumerator SpawnWave()
        {
            Wave wave = waves[waveIndex];
            EnemyAlive = wave.count[waveIndex];
            for (int i = 0; i < wave.count[waveIndex]; i++)
            {
                for (int j = 0; j < wave.enemy.Length; j++)
                {
                    SpawnEnemy(wave.enemy[j]);
                    yield return new WaitForSeconds(1f / wave.rate);
                }
            }

            waveIndex++;
        }

        void SpawnEnemy(GameObject enemy)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}