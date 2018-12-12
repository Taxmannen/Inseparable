using UnityEngine;

/* Script made by Adam */
public class MovementController : MovementScript
{
    [HideInInspector] public bool grounded;

    [Header("Air Variables")]
    public LayerMask groundLayer;
    //[Range(50, 100)]
    public float maxAirSpeed;
    //[Range(50, 100)]
    public float flatAirMultiplier;

    [Header("Ground Variables")]
    //[Range(50, 100)]
    public float maxGroundSpeed;
    //[Range(50, 100)]
    public float flatGroundMultiplier;

    Rigidbody2D rb;

    float xInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal " + gameObject.name);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);
        if (grounded)
        {
            //rb.AddForce(-Physics2D.gravity.normalized * jumpForce + Physics2D.gravity.normalized * (jumpForceReduction * (1 - (jumpTimeCounter / jumpTime))));
            //jumpTimeCounter -= Time.deltaTime;
            rb.AddForce(new Vector2((maxGroundSpeed - Mathf.Abs(rb.velocity.x)) * xInput * Time.deltaTime * flatGroundMultiplier, 0));
            //rb.velocity = new Vector2(rb.velocity.x * (1 - newSpeedfraction) + newSpeedfraction * xInput * groundSpeed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.AddForce(new Vector2((maxAirSpeed - Mathf.Abs(rb.velocity.x)) * xInput * Time.deltaTime * flatAirMultiplier, 0));
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        Rigidbody2D otherRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector3 b = collision.transform.position - transform.position;

        Vector3 a = otherRigidbody2D.velocity;
        //a1 == (a . b) / (b . b) * b
        Vector3 a1 = Vector3.Dot(a, b) / Vector3.Dot(b, b) * b;
        Vector3 a2 = a - a1;

        otherRigidbody2D.velocity = a1 * -1 + a2;
        otherRigidbody2D.velocity *= 1;
    }*/

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector2(transform.position.x - 0.35f, transform.position.y), new Vector2(0.1f, 0.5f));
        Gizmos.DrawCube(new Vector2(transform.position.x + 0.35f, transform.position.y), new Vector2(0.1f, 0.5f));
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));
    }
}