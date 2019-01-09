    using UnityEngine;

    public class StoneRoll : MonoBehaviour
    {
        public float force;
        Rigidbody2D rb;
        public CircleCollider2D colli;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) <= 0.5f) colli.enabled = false;
        else                                  colli.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            rb.AddForce(new Vector2(-force, 0), ForceMode2D.Impulse);
        }
    }
}
