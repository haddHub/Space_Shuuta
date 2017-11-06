using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemiesType;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private Transform[] spawnPositions;

    public void SpawnRandomEnemies(int enemyCount)
    {
        List<Transform> spawnAvailable = new List<Transform>(spawnPositions);

        for (int i = 0; i < enemyCount; i++)
        {
            int type = Random.Range(0, enemiesType.Length);
            int spawn = Random.Range(0, spawnAvailable.Count);

            GameObject enemy = Instantiate(enemiesType[type], spawnAvailable[spawn].position, Quaternion.identity, transform);

            spawnAvailable.RemoveAt(spawn);
        }
    }

    public void SpawnBoss()
    {
        GameObject enemy = Instantiate(boss, spawnPositions[2].position, Quaternion.identity, transform);
    }
}