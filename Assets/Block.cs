using UnityEngine;

public class Block : MonoBehaviour
{
    public float gravityScaleFactor = 20f;
    void Start()
    {
        GetComponent<Rigidbody>().mass += Time.timeSinceLevelLoad / gravityScaleFactor;
    }
    void Update()
    {
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
