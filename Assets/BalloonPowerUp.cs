using UnityEngine;

public class BalloonPowerUp : MonoBehaviour {
    public bool on;
    public Vector2 force;
    public float gravityScale;

    Rigidbody2D rb;
    string button;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        button = "Seperate" + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
    }
	
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal" + " " + gameObject.name); 
        float y = Input.GetAxisRaw("Horizontal" + " " + gameObject.name); 
        if (Input.GetButtonDown(button)) on = !on;
        if (on)
        {
            if (transform.localScale.x < 7)
            {
                transform.localScale = new Vector2(transform.localScale.x + 0.025f, transform.localScale.y + 0.025f);
            }
            rb.gravityScale = gravityScale;
            Debug.Log(force.x + x + " " + force.y + y);
            rb.AddForce(new Vector2(force.x + x, force.y + y), ForceMode2D.Impulse);
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
