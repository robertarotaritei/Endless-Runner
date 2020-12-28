using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;

    public float mapWidth = 9f;

    public GameObject restartUI;

    private Rigidbody rb;

    private bool dieOnce = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var sidewaysForce = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        var newPosition = rb.position + Vector3.right * sidewaysForce;

        newPosition.x = Mathf.Clamp(newPosition.x, - mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter()
    {
        if(!dieOnce)
        {
            AudioManager.instance.Play("PlayerDeath");
            dieOnce = true;
        }

        FindObjectOfType<Manager>().EndGame();
    }
}
