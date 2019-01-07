using UnityEngine;

enum JumpState
{
    CanJump, IsJumping, HasJumped
}

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
    Animator anim;

    public Transform rightArm;
    public Transform leftArm;

    JumpState state;

    string jumpButtonStr;

    public ParticleSystem jumpParticle;
    

    void Start()
    {
        state = JumpState.CanJump;
        jumpButtonStr = "Jump " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }

    void onJumpStart()
    {

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

        if (jumpButton && state == JumpState.CanJump) {
            AudioManager.Play("Jump");
            anim.Play("Jump");
            jumpParticle.Play();
            GameObject g = Instantiate(jumpParticle, transform.position, Quaternion.identity).gameObject;
            Destroy(g, 0.5f);
            state = JumpState.IsJumping;
        }

        if (state == JumpState.IsJumping && !grounded)
        {
            Vector3 scale = rightArm.localScale;
            scale.y = 2f;
            rightArm.localScale = scale;
            leftArm.localScale = scale;
            anim.Play("Jump Wiggle");
        }
        else
        {
            Vector3 scale = rightArm.localScale;
            scale.y = 1f;
            rightArm.localScale = scale;
            leftArm.localScale = scale;
        }

        if (!jumpButton && state == JumpState.IsJumping)
        {
            if (grounded)
            {
                jumpTimeCounter = jumpTime;
                state = JumpState.CanJump;
                AudioManager.Play("Land");
                anim.Play("Idle");
                //Anim JUMP!
            }
            else jumpTimeCounter = 0;
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