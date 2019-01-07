    using UnityEngine;

    public class StoneRoll : MonoBehaviour
    {
        public float force;
        Rigidbody2D rb;
        DamageToPlayer dmg;
        bool canHurtPlayer = true;
        public CircleCollider2D colli;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Debug.Log(gameObject.name);
            dmg = GetComponentInChildren<DamageToPlayer>();
        }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Abs(rb.velocity.x));

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

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
                
        }
    }
}
