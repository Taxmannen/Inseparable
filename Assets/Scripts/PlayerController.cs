using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal " + gameObject.name) * speed;
        rb.velocity = new Vector2( x, rb.velocity.y);
	}
}
