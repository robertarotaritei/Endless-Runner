using UnityEngine;

public class LongSpawner : Spawner
{
    private int randomSpawn;

    public LongSpawner(GameObject block, Transform[] spawnPoints)
    {
        base.block = block;
        base.spawnPoints = spawnPoints;
        Start();
    }

    public override void Start()
    {
        randomSpawn = Random.Range(0, spawnPoints.Length);
        timeToSpwan += 1f;
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

    int ChooseNewSpawnPoint()
    {
        if (Random.Range(0, 2) == 0)
        {
            if (randomSpawn > 1)
            {
                return Random.Range(0, randomSpawn);
            }

            return Random.Range(randomSpawn + 1, spawnPoints.Length);
        }
        else
        {
            if (randomSpawn < 3)
            {
                return Random.Range(randomSpawn + 1, spawnPoints.Length);
            }
                
            return  Random.Range(0, randomSpawn);
        }
    }

    void SpawnBlocks(GameObject block)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomSpawn == i)
            {
                var spawnPoint = new Vector3(spawnPoints[i].position.x, spawnPoints[i].position.y - 2, spawnPoints[i].position.z);
                Instantiate(block, spawnPoint, Quaternion.identity);
            }
        }

        randomSpawn = ChooseNewSpawnPoint();
    }
}
