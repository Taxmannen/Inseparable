using UnityEngine;

public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public bool drawGizmos;
    public float speed;
    public float fraction;

    Rigidbody2D rb;
    bool grounded;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);

        float x = Input.GetAxisRaw("Horizontal " + gameObject.name) * speed;
       // rb.velocity = new Vector2(rb.velocity.x * (1f - fraction) + x * fraction, rb.velocity.y);
        rb.AddForce(new Vector2(x, 0));
    }

    void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));
        }    
    }
}
