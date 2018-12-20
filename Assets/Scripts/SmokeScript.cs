using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public LayerMask ground;
    private ParticleSystem ps;
    Rigidbody2D rb;

    void Start()
    {
        //grounded = transform.parent.gameObject.GetComponent<MovementController>().grounded;
        ps = gameObject.GetComponent<ParticleSystem>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        var emission = ps.emission;
        emission.rateOverTime = 10f;
        if (GetPlayer.playerReady(transform.parent.gameObject.name))
        if (GetPlayer.getPlayerGroundedByName(transform.parent.gameObject.name, ground) && (Input.GetButton("Horizontal " + transform.parent.gameObject.name)))
        {
            emission.enabled = true;
        }
        else
            emission.enabled = false;
    }



}

