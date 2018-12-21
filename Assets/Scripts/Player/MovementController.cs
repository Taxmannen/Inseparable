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
    public float pushPower;

    bool facingRight;
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
        grounded = GetPlayer.getPlayerGroundedByName(gameObject.name, groundLayer); 
        if (grounded) {
            rb.AddForce(new Vector2((maxGroundSpeed - Mathf.Abs(rb.velocity.x)) * xInput * Time.deltaTime * flatGroundMultiplier, 0));
            if(GetPlayer.otherPlayerReady(gameObject.name) && !GetPlayer.getOtherPlayerGroundedStrictByName(gameObject.name, groundLayer))
            {
                Transform player = GetPlayer.getPlayerByName(gameObject.name);
                Transform otherPlayer = GetPlayer.getOtherPlayerByName(gameObject.name);

                if(player.position.y > otherPlayer.position.y + 0.1f)
                {
                    if (xInput > 0 && player.position.x > otherPlayer.position.x)
                        rb.AddForce(new Vector2(pushPower * xInput, 0));
                    else if (xInput < 0 && player.position.x < otherPlayer.position.x)
                        rb.AddForce(new Vector2(pushPower * xInput, 0));
                }
                    
            }

        }
        else {
            rb.AddForce(new Vector2((maxAirSpeed - Mathf.Abs(rb.velocity.x)) * xInput * Time.deltaTime * flatAirMultiplier, 0));
        }
        if      (xInput > 0 && !facingRight) facingRight = Flip();
        else if (xInput < 0 && facingRight)  facingRight = Flip();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector2(transform.position.x - 0.35f, transform.position.y), new Vector2(0.1f, 0.5f));
        Gizmos.DrawCube(new Vector2(transform.position.x + 0.35f, transform.position.y), new Vector2(0.1f, 0.5f));
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));
    }

    bool Flip()
    {
        bool facingRight = false;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        if (theScale.x > 0) facingRight = true;
        transform.localScale = theScale;
        return facingRight;
    }
}