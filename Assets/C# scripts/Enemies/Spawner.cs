using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ScriptableObject
{
    public Transform[] spawnPoints;
    public GameObject block;
    public float timeToSpwan = Time.timeSinceLevelLoad;
    public float timeBetweenWaves = 2f;
    public abstract void Start();
    public abstract void FixedUpdate();
}
