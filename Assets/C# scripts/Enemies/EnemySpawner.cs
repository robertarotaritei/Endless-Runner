using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject basicBlock;
    public GameObject fastBlock;
    public float timeToChange = 15f;
    private float timeToSpawn = 15f;
    private int randomEnemy = 0;
    private Spawner enemy;

    void Start()
    {
        enemy = new BasicSpawner(basicBlock, spawnPoints);
    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawn && Time.timeSinceLevelLoad >= enemy.timeToSpwan)
        {
            randomEnemy = Random.Range(0, 2);
            switch (randomEnemy)
            {
                case 0:
                    enemy = new BasicSpawner(basicBlock, spawnPoints);
                    break;
                case 1:
                    enemy = new FastSpawner(fastBlock, spawnPoints);
                    break;
            }

            timeToSpawn = Time.time + timeToChange;
        }
        enemy.FixedUpdate();
    }
}
