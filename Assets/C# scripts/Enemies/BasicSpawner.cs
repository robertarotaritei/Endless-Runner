using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : Spawner
{
    public BasicSpawner(GameObject block, Transform[] spawnPoints)
    {
        base.block = block;
        base.spawnPoints = spawnPoints;
        Start();
    }
    public override void Start()
    {
        timeBetweenWaves = 1.7f;
        timeToSpwan = 1f;
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
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(block, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
