using UnityEngine;

/* Script made by Adam */
public class AnchorController : MovementScript
{
    bool anchorButton;
    public bool grounded;

    public LayerMask groundLayer;
    private Rigidbody2D rb;

    string anchorButtonStr;

    void Start()
    {
        anchorButtonStr = "Anchor" + " " + gameObject.name + " " + "XBOX";
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);
        float anchorAxis = Input.GetAxisRaw(anchorButtonStr);
        if (anchorAxis > 0.19f) anchorButton = true;
        else anchorButton = false;

        if (!anchorButton && rb.isKinematic)
        {
            rb.isKinematic = false;
        }
        else if(anchorButton && !rb.isKinematic)
        {
            if (grounded)
            {
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
            }
        }
    }
}