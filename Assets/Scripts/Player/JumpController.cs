using UnityEngine;

/* Script made by Adam */
public class JumpController : MovementScript
{
    //[Range(1f, 150f)]
    public float jumpForce;
    //[Range(0.01f, 0.5f)]
    public float jumpTime;
    public float jumpTimeCounter;

    //[Range(0f, 150f)]
    public float jumpForceReduction;

    bool jumpButton;
    public bool grounded;

    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public JumpController otherPlayerJumpController;
    private Rigidbody2D rb;

    string jumpButtonStr;

    void Start()
    {
        jumpButtonStr = "Jump " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
        
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        grounded = GetPlayer.getPlayerGroundedByName(gameObject.name, groundLayer);
        if (otherPlayerJumpController == null)
        {
            if (GetPlayer.otherPlayerReady(gameObject.name))
                otherPlayerJumpController = GetPlayer.getOtherPlayerByName(gameObject.name).GetComponent<JumpController>();
        }
        else
            if (!grounded && GetPlayer.getOtherPlayerGroundedByName(gameObject.name, groundLayer))
            {
                Collider2D[] collisions = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.5f), 0, playerLayer);
                foreach(Collider2D collision in collisions){
                    if (collision.gameObject.name.CompareTo(gameObject.name) != 0){
                        grounded = true;
                    }
                }
            }

        jumpButton = Input.GetButton(jumpButtonStr);
         
        if (!jumpButton)
        {
            if (grounded) jumpTimeCounter = jumpTime;
            else          jumpTimeCounter = 0;
        }
    }

    void FixedUpdate()
    {
        if (jumpButton && jumpTimeCounter > 0)
        {
            if (jumpTimeCounter == jumpTime)
            {
                //Play sound;
            }

            rb.AddForce(-Physics2D.gravity.normalized * jumpForce + Physics2D.gravity.normalized * (jumpForceReduction * (1 - (jumpTimeCounter / jumpTime))));
            jumpTimeCounter -= Time.deltaTime;
            if (jumpTimeCounter < 0) jumpTimeCounter = 0;
        }
    }
}