using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject block;
    public float timeBetweenWaves = 2f;
    private float timeToSpwan = 2f;
    private bool falling = true;

    void Start()
    {

    }

    void Update()
    {
        if(Time.time >= timeToSpwan)
        {
            SpawnBlocks();

            timeToSpwan = Time.time + timeBetweenWaves;
        }
    }

    void SpawnBlocks()
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
