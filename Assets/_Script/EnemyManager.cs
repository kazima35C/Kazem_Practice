using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        [SerializeField] private List<Enemy> enemysPrefab;
        [SerializeField] private List<Enemy> enemies;
        [SerializeField] private List<WaveEnemy> enemyWave;

        [SerializeField] private float distanceOfPlayer = 10;


        private void Start()
        {
            StartCoroutine(UpdateCreator2());
        }

        private IEnumerator UpdateCreator2()
        {
            int indexWave = 0;
            while (true)
            {
                while (TimeManager.Instance.IsPause.Value) { yield return null; }
                while (GameManager.Instance.HealthPlayer<=0) { yield break; }
                CreatEnemy();
                indexWave = indexWave >= enemyWave.Count ? (enemyWave.Count - 1) : indexWave;
                indexWave = enemyWave[indexWave].timeChangeWave < Time.time ? indexWave + 1 : indexWave;
                indexWave = indexWave >= enemyWave.Count ? (enemyWave.Count - 1) : indexWave;
                float enemyCreationInterval = enemyWave[indexWave].enemyCreationInterval;
                yield return new WaitForSeconds(enemyCreationInterval);
            }
        }


        private void CreatEnemy()
        {
            int randomAngle = UnityEngine.Random.Range(0, 360);
            Vector3 positionEnemy = new((float)Math.Cos(randomAngle) * distanceOfPlayer,
            1, (float)Math.Sin(randomAngle) * distanceOfPlayer);
            Enemy enemy = Instantiate(enemysPrefab[UnityEngine.Random.Range(0, enemysPrefab.Count)], positionEnemy, Quaternion.identity);
            enemies.Add(enemy);
        }


        private void Update()
        {
            if (TimeManager.Instance.IsPause.Value) { return; }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].UpdateEnemy();
            }
        }
        public void RemoveEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }
    }
    [System.Serializable]
    public class WaveEnemy
    {
        public float enemyCreationInterval;
        public float timeChangeWave;
    }
}
