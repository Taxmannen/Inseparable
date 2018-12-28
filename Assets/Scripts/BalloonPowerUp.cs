using UnityEngine;

public class BalloonPowerUp : MonoBehaviour {
    public bool on;
    public Vector2 force;
    public float gravityScale;

    public SpriteRenderer sr;

    Rigidbody2D rb;
    string button;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        button = "Seperate" + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
    }
	
	void Update ()
    {
        transform.rotation = Quaternion.identity;

        float x = Input.GetAxis("Horizontal" + " " + gameObject.name)/8; 
        float y = Input.GetAxis("Vertical"   + " " + gameObject.name)/10; 
        
        if (Input.GetButtonDown(button)) on = !on;
        if (on)
        {
            if (transform.localScale.x < 7)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.025f, transform.localScale.y + 0.025f, transform.localScale.y + 0.025f);
            }
            rb.gravityScale = gravityScale;
            rb.AddForce(new Vector2(force.x + x, force.y + y), ForceMode2D.Impulse);

            //Debug.Log("Force X" + " " + (force.x + x));
            //Debug.Log("Force Y" + " " + (force.y + y));
        }
        else
        {
            if (transform.localScale.x > 4)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.04f, transform.localScale.y - 0.04f, transform.localScale.y - 0.04f);
            }
            rb.gravityScale = 1;
        }
	}
}
