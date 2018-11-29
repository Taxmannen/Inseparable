using UnityEngine;

/* Script made by Daniel and Adam */
public class PlayerController : MonoBehaviour {
    [Header("Air Variables")]
    public LayerMask groundLayer;
    [Range(1, 10)]
    public float airForce;

    [Header("Ground Variables")]
    [Range(1, 10)]
    public float groundSpeed;
    [Range(0.01f, 0.9f)]
    public float newSpeedfraction;

    Rigidbody2D rb;
    bool grounded;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);
        float x = Input.GetAxisRaw("Horizontal " + gameObject.name);
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * (1 - newSpeedfraction) + newSpeedfraction * x * groundSpeed, rb.velocity.y);
        }
        else
        {
            rb.AddForce(new Vector2(x * airForce, 0));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));    
    }
}
