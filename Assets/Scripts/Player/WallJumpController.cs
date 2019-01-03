using UnityEngine;

/* Script made by Adam */
public class WallJumpController : MovementScript
{
    //[Range(50, 100)]
    public float maxGroundSpeed;
    //[Range(50, 100)]
    public float flatGroundMultiplier;

    bool jumpButton;
    public bool wallContact;

    public LayerMask groundLayer;
    private Rigidbody2D rb;

    string jumpButtonStr;

    void Start()
    {
        jumpButtonStr = "Jump " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];

        jumpButton = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        wallContact =  Physics2D.OverlapBox(new Vector2(transform.position.x - 0.35f, transform.position.y), new Vector2(0.1f, 0.5f), 0, groundLayer)
                    || Physics2D.OverlapBox(new Vector2(transform.position.x + 0.35f, transform.position.y), new Vector2(0.1f, 0.5f), 0, groundLayer);

        jumpButton = Input.GetButton(jumpButtonStr);

        if (jumpButton && wallContact)
        {
            jumpTimeCounter = jumpTime;
            AudioManager.Play("WallJump");
        }
            
        else
            jumpTimeCounter = 0;
    }

    void FixedUpdate()
    {
        if (jumpButton && wallContact)
        {
            float maxSpeed = maxGroundSpeed;
            if (GetPlayer.otherPlayerReady(gameObject.name))
            {
                Transform otherPlayer = GetPlayer.getOtherPlayerByName(gameObject.name);
                WallJumpController otherController = otherPlayer.GetComponent<WallJumpController>();

                if(otherController.jumpButton && otherController.wallContact) {
                    maxSpeed *= 0.65f;
                    Debug.Log("Limiting!");
                }
            }
            //Debug.Log("Walljumping!");
            //rb.AddForce(-Physics2D.gravity.normalized * jumpForce + Physics2D.gravity.normalized * (jumpForceReduction * (1 - (jumpTimeCounter / jumpTime))));
            
            rb.AddForce(-Physics2D.gravity.normalized * (maxGroundSpeed - Mathf.Abs(rb.velocity.y)) * Time.deltaTime * flatGroundMultiplier, 0);
        }
    }
}