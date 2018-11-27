using UnityEngine;

/* Script made by Daniel and Adam */
public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public bool drawGizmos;
    [Range(1, 10)]
    public float speed;

    Rigidbody2D rb;
    bool grounded;
    bool jumpAvaliable;
    int jumping;

    //Jump Variables
    public int jumpPower;
    public int jumpCycles;
    public float jumpCycleInterval;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAvaliable = true;
        jumping = 0;
	}

    void Jump()
    {
        Vector2 jumpVector = new Vector2(0, jumpPower);
        rb.AddForce(jumpVector);

        if (jumping-- > 0 && Input.GetButton("Jump " + gameObject.name))
            Invoke("Jump", jumpCycleInterval);
        else
            jumping = 0;
    }

	void Update ()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);

        float x = Input.GetAxisRaw("Horizontal " + gameObject.name) * speed;
        rb.AddForce(new Vector2(x, 0));

        if (grounded && !jumpAvaliable && jumping == 0)
            jumpAvaliable = true;

        if (jumpAvaliable && Input.GetButtonDown("Jump " + gameObject.name))
        {
            jumpAvaliable = false;
            jumping = jumpCycles;
            Jump();
        }

    }

    void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));
        }    
    }
}
