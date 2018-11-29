using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Range(1, 150)]
    public float jumpForce;
    [Range(0.1f, 2f)]
    public float jumpTime;
    [Range(0.01f, 0.2f)]
    public float jumpTimeCounter;

    bool jumpButton;
    bool hasReleasedButton;
    bool grounded;

    public LayerMask groundLayer;
    public bool stoppedJumping;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        jumpButton = Input.GetButton("Jump " + gameObject.name);
    }

    void FixedUpdate()
    {
        if (jumpButton)
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        if (jumpButton && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (jumpButton)
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }
}