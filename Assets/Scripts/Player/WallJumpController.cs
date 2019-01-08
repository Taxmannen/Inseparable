using UnityEngine;

/* Script made by Adam */
public class WallJumpController : MovementScript
{
    public float maxGroundSpeed;
    public float flatGroundMultiplier;

    bool jumpButton;
    public bool wallContact;
    bool wallContactLeftSide;
    bool wallContactRightSide;

    public LayerMask groundLayer;
    private Rigidbody2D rb;

    string jumpButtonStr;

    public ParticleSystem jumpParticle;

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

        wallContactLeftSide = Physics2D.OverlapBox(new Vector2(transform.position.x - 0.35f, transform.position.y), new Vector2(0.1f, 0.5f), 0, groundLayer);
        wallContactRightSide = Physics2D.OverlapBox(new Vector2(transform.position.x + 0.35f, transform.position.y), new Vector2(0.1f, 0.5f), 0, groundLayer);
        jumpButton = Input.GetButton(jumpButtonStr);
    }

    void FixedUpdate()
    {
        if (jumpButton && wallContact)
        {
            
            jumpParticle.Play();
            GameObject g = Instantiate(jumpParticle, transform.position, Quaternion.identity).gameObject;
            g.name = gameObject.name;
            if (wallContactRightSide)
            {
                g.transform.position = new Vector3(g.transform.position.x + 0.4f, g.transform.position.y - 0.3f, g.transform.position.z);
            }
            if (wallContactLeftSide)
                {
                    g.transform.position = new Vector3(g.transform.position.x - 0.4f, g.transform.position.y - 0.3f, g.transform.position.z);
                }
            Destroy(g, 0.5f);
            float maxSpeed = maxGroundSpeed;
            if (GetPlayer.otherPlayerReady(gameObject.name))
            {
                Transform otherPlayer = GetPlayer.getOtherPlayerByName(gameObject.name);
                WallJumpController otherController = otherPlayer.GetComponent<WallJumpController>();

                if(otherController.jumpButton && otherController.wallContact) {
                    maxSpeed *= 0.65f;
                }
            }
            rb.AddForce(-Physics2D.gravity.normalized * (maxGroundSpeed - Mathf.Abs(rb.velocity.y)) * Time.deltaTime * flatGroundMultiplier, 0);
        }
    }
}