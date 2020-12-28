using UnityEngine;

public class LongBlock : Block
{
    public override void Start()
    {
        gravityScaleFactor = 10f;
        GetComponent<Rigidbody>().mass += Time.timeSinceLevelLoad / gravityScaleFactor;
    }

    public override void FixedUpdate()
    {
        if (transform.position.y < -12f)
        {
            FindObjectOfType<Score>().score += 1f;
            AudioManager.instance.Play("ScoreUp");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var fadeToWhite = base.GetComponent<Animator>();
            fadeToWhite.Play("FadeToWhite");
        }
    }
}
