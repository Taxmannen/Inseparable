using UnityEngine;

/* Script made by Daniel and Adam */
public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public bool drawGizmos;
    [Range(1, 10)]
    public float speed;

    Rigidbody2D rb;
    bool grounded;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        grounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f), 0, groundLayer);

        float x = Input.GetAxisRaw("Horizontal " + gameObject.name) * speed;
        rb.AddForce(new Vector2(x, 0));
    }

    void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.35f), new Vector2(0.5f, 0.1f));
        }    
    }
}
