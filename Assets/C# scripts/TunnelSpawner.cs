using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject block;
    public float timeBetweenWaves = 0.5f;
    private float timeToSpwan = 2f;
    private int randomSpawn;
    void Start()
    {
        randomSpawn = Random.Range(0, spawnPoints.Length);
    }

    void Update()
    {
        if (Time.time >= timeToSpwan)
        {
            SpawnBlocks();
            int left = randomSpawn - 1;
            int right = randomSpawn + 1;
            if(left < 0)
            {
                left++;
            }
            if(right >= spawnPoints.Length)
            {
                right--;
            }
            randomSpawn = Random.Range(left, right);
            timeToSpwan = Time.time + timeBetweenWaves;
        }
    }

    void SpawnBlocks()
    {

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomSpawn != i)
            {
                Instantiate(block, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
