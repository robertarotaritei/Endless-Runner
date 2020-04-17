using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSpawner : Spawner
{
    private int randomSpawn;
    public FastSpawner(GameObject block, Transform[] spawnPoints)
    {
        base.block = block;
        base.spawnPoints = spawnPoints;
        Start();
    }
    public override void Start()
    {
        randomSpawn = Random.Range(0, spawnPoints.Length);
        timeToSpwan = 1f;
        timeBetweenWaves = 1f;
    }

    public override void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad >= timeToSpwan)
        {
            SpawnBlocks(block);
            timeToSpwan = Time.timeSinceLevelLoad + timeBetweenWaves;
        }
    }

    void SpawnBlocks(GameObject block)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomSpawn != i)
            {
                Instantiate(block, spawnPoints[i].position, Quaternion.identity);
            }
        }

        int left = randomSpawn - 1;
        int right = randomSpawn + 1;
        if (left < 0)
        {
            left++;
        }
        if (right >= spawnPoints.Length)
        {
            right--;
        }
        randomSpawn = Random.Range(left, right + 1);
    }
}
