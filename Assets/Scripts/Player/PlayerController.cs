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
    public float maxGroundSpeed;
    public float flatMultiplier;

    Rigidbody2D rb;
    bool grounded;
    float xInput;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal " + gameObject.name);
    }

    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);
        if (grounded)
        {
            //rb.AddForce(-Physics2D.gravity.normalized * jumpForce + Physics2D.gravity.normalized * (jumpForceReduction * (1 - (jumpTimeCounter / jumpTime))));
            //jumpTimeCounter -= Time.deltaTime;
            rb.AddForce(new Vector2((maxGroundSpeed - Mathf.Abs(rb.velocity.x)) * xInput * Time.deltaTime * flatMultiplier, 0));
            //rb.velocity = new Vector2(rb.velocity.x * (1 - newSpeedfraction) + newSpeedfraction * xInput * groundSpeed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.AddForce(new Vector2(xInput * airForce, 0));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));    
    }
}
