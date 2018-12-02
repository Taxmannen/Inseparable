using UnityEngine;

/* Script made by Daniel */
public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public float groundSpeed;
    public float airSpeed;
    public float jumpForce;

    Rigidbody2D rb;
    bool grounded;
    float xInput;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);
        xInput = Input.GetAxisRaw("Horizontal" + " " + gameObject.name);
        if (Input.GetButtonDown("Jump" + " " + gameObject.name) && grounded) rb.AddForce(new Vector2(0, jumpForce * 100));
    }

    void FixedUpdate()
    {

        if (grounded) rb.AddForce(new Vector2(xInput * groundSpeed, 0));
        else          rb.AddForce(new Vector2(xInput * airSpeed, 0));
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));    
    }
}
