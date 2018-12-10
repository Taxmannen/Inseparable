using System.Collections;
using System.Collections.Generic;
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
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);
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
            rb.AddForce(-Physics2D.gravity.normalized * jumpForce + Physics2D.gravity.normalized * (jumpForceReduction * (1 - (jumpTimeCounter / jumpTime))));
            jumpTimeCounter -= Time.deltaTime;
            if (jumpTimeCounter < 0) jumpTimeCounter = 0;
        }
    }
}