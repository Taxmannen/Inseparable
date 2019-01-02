﻿using UnityEngine;

/* Script made by Daniel */
public class BalloonPowerUp : MonoBehaviour {
    public bool on;
    public Vector2 force;

    Rigidbody2D rb;
    string button;

    Light characterLight;
    float lightSize;
    bool inflated;
    bool empty;
    MovementController mc;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        mc = GetComponent<MovementController>();
        characterLight = GetComponentInChildren<Light>();
        lightSize = characterLight.range;
        button = "Seperate" + " " + gameObject.name + " " + Main.controllers[transform.GetSiblingIndex()];
    }
	
	void Update ()
    {
        float x = Input.GetAxis("Horizontal" + " " + gameObject.name)/8; 
        float y = Input.GetAxis("Vertical"   + " " + gameObject.name)/10;

        if (Input.GetButtonDown(button))
        {
            on = !on;
        }
        if (on)
        {
            if (!inflated)
            {
                if (mc.facingRight) transform.localScale = new Vector3(transform.localScale.x + 0.025f, transform.localScale.y + 0.025f, 1);
                else                transform.localScale = new Vector3(transform.localScale.x - 0.025f, transform.localScale.y + 0.025f, 1);
                if (characterLight.range < lightSize * 4) characterLight.range += 0.2f;
                if (characterLight.range > lightSize * 4) characterLight.range = lightSize * 4;
                if (transform.localScale.x >= 2 || transform.localScale.x <= -2)
                {
                    inflated = true;
                    empty = false;
                }
            }
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(force.x + x, force.y + y), ForceMode2D.Impulse);
        }
        else
        {
            if (!empty && transform.localScale.y > 1)
            {
                if (mc.facingRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.025f, transform.localScale.y - 0.025f, 1);
                    if (transform.localScale.x < 1) transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.025f, transform.localScale.y - 0.025f, 1);
                    if (transform.localScale.x > -1) transform.localScale = new Vector3(-1, 1, 1);
                }

                if (characterLight.range > lightSize) characterLight.range -= 0.3f;
                if (characterLight.range < lightSize) characterLight.range = lightSize;

                if (transform.localScale.x == 1 || transform.localScale.x == -1)
                {
                    empty = true;
                    inflated = false;
                }
            }
            rb.gravityScale = 1;
        }
	}
}