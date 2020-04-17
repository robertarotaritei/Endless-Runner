using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int enemyType = 1;
    public GameObject basicSpawner, tunnelSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad % 5 == 0)
        {
            enemyType = (enemyType + 1) % 2;
            switch (enemyType)
            {
                case 0:
                    if (tunnelSpawner != null)
                    {
                        Destroy(tunnelSpawner);
                    }
                    Instantiate(basicSpawner, transform.position, Quaternion.identity);
                    break;
                case 1:
                    if (basicSpawner != null)
                    {
                        Destroy(basicSpawner);
                    }
                    Instantiate(tunnelSpawner, transform.position, Quaternion.identity);
                    break;
            }
        }
    }
}
