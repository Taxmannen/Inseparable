using UnityEngine;

public class BalloonPowerUp : MonoBehaviour {
    public bool on;
    public Vector2 force;
    public float gravityScale;

    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (on)
        {
            if (transform.localScale.x < 7)
            {
                transform.localScale = new Vector2(transform.localScale.x + 0.025f, transform.localScale.y + 0.025f);
            }
            rb.gravityScale = gravityScale;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            if (transform.localScale.x > 4)
            {
                transform.localScale = new Vector2(transform.localScale.x - 0.04f, transform.localScale.y - 0.04f);
            }
            rb.gravityScale = 1;
        }
	}
}
