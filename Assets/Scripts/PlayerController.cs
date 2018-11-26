using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float fraction;

    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal " + gameObject.name) * speed;
        rb.velocity = new Vector2(rb.velocity.x * (1f - fraction) + x * fraction, rb.velocity.y);
	}
}
