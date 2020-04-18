using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public float gravityScaleFactor = 20f;
    public abstract void Start();
    public abstract void FixedUpdate();
}
