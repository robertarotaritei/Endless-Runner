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
        timeToSpwan += 0.5f;
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

    void ChooseNewSpawnPoint()
    {
        var left = randomSpawn - 1;
        var right = randomSpawn + 1;
        if (left < 0)
        {
            left++;
            randomSpawn = Random.Range(0, 3);
            randomSpawn = randomSpawn == 0 ? left : right;
        }
        else
        {
            if (right >= spawnPoints.Length)
            {
                right--;
                randomSpawn = Random.Range(0, 3);
                randomSpawn = randomSpawn == 0 ? right : left;
            }
            else
            {
                randomSpawn = Random.Range(0, 5);
                randomSpawn = randomSpawn < 2 ? left : randomSpawn == 2 ? left + 1 : right;
            }
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
        ChooseNewSpawnPoint();
    }
}
