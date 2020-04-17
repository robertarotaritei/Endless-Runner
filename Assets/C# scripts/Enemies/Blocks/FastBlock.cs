using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBlock : Block
{
    public override void Start()
    {
        gravityScaleFactor = 10f;
        GetComponent<Rigidbody>().mass += Time.timeSinceLevelLoad / gravityScaleFactor;
    }
    public override void FixedUpdate()
    {
        if (transform.position.y < -10f)
        {
            FindObjectOfType<Score>().score += 0.25f;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter()
    {
        FadeToWhite();
    }
}
