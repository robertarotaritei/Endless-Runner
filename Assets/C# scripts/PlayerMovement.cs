using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float mapWidth = 9f;
    public GameObject restartUI;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var sidewaysForce = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        var newPosition = rb.position + Vector3.right * sidewaysForce;

        newPosition.x = Mathf.Clamp(newPosition.x, - mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter()
    {
        FindObjectOfType<Manager>().EndGame();
    }
}
