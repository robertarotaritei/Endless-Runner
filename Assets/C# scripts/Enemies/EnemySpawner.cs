using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject basicBlock;
    public GameObject fastBlock;
    public GameObject longBlock;
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
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            if (Time.timeSinceLevelLoad >= enemy.timeToSpwan)
            {
                randomEnemy = Random.Range(0, 3);
                switch (randomEnemy)
                {
                    case 0:
                        enemy = new BasicSpawner(basicBlock, spawnPoints);
                        break;
                    case 1:
                        enemy = new FastSpawner(fastBlock, spawnPoints);
                        break;
                    case 2:
                        enemy = new LongSpawner(longBlock, spawnPoints);
                        break;
                }

                timeToSpawn = Time.timeSinceLevelLoad + timeToChange;
            }
        }
        enemy.FixedUpdate();
    }
}
