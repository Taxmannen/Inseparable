﻿using System;
using UnityEngine;

/* Script made by Daniel */
public class ThrowPlayer : MovementScript {
    public LayerMask playerLayer;
    public Vector2 power = new Vector2(20, 25);
    public bool pickup;

    MovementController movementController;
    Transform player;
    Rigidbody2D rb;

    bool buttonUpThrow;
    string throwButtonStr;
    string pickupButtonStr;
    float pickupTime;

    public Transform leftArmParent;
    public GameObject leftArm;
    public Transform rightArmParent;
    public GameObject rightArm;
    public float i=0;

    public Vector3 rightArmStartPosition;
    public Vector3 rightArmStartAngles;
    public Vector3 leftArmStartPosition;
    public Vector3 leftArmStartAngles;

    public GameObject aimParent;

    void Start ()
    {
        throwButtonStr  = "Throw"  + " " + gameObject.name + " " + "XBOX";
        pickupButtonStr = "Pickup" + " " + gameObject.name + " " + "XBOX";
        string otherPlayer;
		if      (gameObject.name == "Player 1") otherPlayer = "Player 2";
		else                                    otherPlayer = "Player 1";
        
        player = GameObject.Find(otherPlayer).transform;
        movementController = GetComponent<MovementController>();
        rb = player.GetComponent<Rigidbody2D>();
        rightArmStartPosition = rightArm.transform.localPosition;
        rightArmStartAngles = rightArm.transform.localEulerAngles;
        leftArmStartPosition = leftArm.transform.localPosition;
        leftArmStartAngles = leftArm.transform.localEulerAngles;
    }

    void Update ()
    {
        bool canPickup = false;
        if (GetPlayer.otherPlayerReady(gameObject.name))
            canPickup = (GetPlayer.getOtherPlayerByName(gameObject.name).position - transform.position).magnitude < 2f;
        
        if (canPickup) PickupManager();
        if (pickup) ThrowManager();
        else
        {
            if (rb.gravityScale == 0) rb.gravityScale = 1;
        }
    }

    private void PickupManager()
    {
        if (Input.GetAxisRaw(pickupButtonStr) > 0.2f && Time.time - pickupTime > 0.3f)
        {
            if (!pickup && movementController.grounded)
            {
                pickup = true;
                rb.gravityScale = 0;
                AudioManager.Play("Pickup");
            }
            else if (pickup)
            {
                pickup = false;
                rb.gravityScale = 1;
            }
            pickupTime = Time.time;
        }
        if (Input.GetAxisRaw(throwButtonStr) < 0.2f)
        {
            buttonUpThrow = true;
        }
    }

    public void setOtherJumpState()
    {
        Transform otherPlayer = GetPlayer.getOtherPlayerByName(gameObject.name);
        JumpController jc = otherPlayer.GetComponent<JumpController>();
        jc.state = JumpState.IsJumping;
    }

    private void ThrowManager()
    {
        if (Input.GetAxisRaw(throwButtonStr) > 0.2f && buttonUpThrow)
        {
            float x = Mathf.Cos((aimParent.transform.eulerAngles.z + 360f) * Mathf.Deg2Rad);
            float y = Mathf.Sin((aimParent.transform.eulerAngles.z + 360f) * Mathf.Deg2Rad);
            
            Vector2 directionVector = new Vector2(x, y);

            rb.gravityScale = 1;
            rb.AddForce(new Vector2(power.x * directionVector.x, power.y * Mathf.Clamp(directionVector.y, 0f, 1f)), ForceMode2D.Impulse);
            pickup = false;
            buttonUpThrow = false;

            Invoke("setOtherJumpState", 0.1f);
            AudioManager.Play("Throw");
        }
        
        if      (!movementController.grounded && rb.gravityScale == 0) rb.gravityScale = 1;
        else if (movementController.grounded  && rb.gravityScale == 1) rb.gravityScale = 0;
    }

    //Following made by Adam
    private void FixedUpdate() {
        if (pickup)
        {
            player.position = Vector3.MoveTowards(player.position, new Vector2(transform.position.x, transform.position.y + 1f), 0.1f);
            updateArms();
        }
        else
        {
            i = 0;
            rightArm.transform.localPosition = rightArmStartPosition * rightArmParent.localScale.x;
            rightArm.transform.localEulerAngles = rightArmStartAngles;
            leftArm.transform.localPosition = leftArmStartPosition;
            leftArm.transform.localEulerAngles = leftArmStartAngles;
        }
    }

    public void updateArms() {
        float max = 4;

        Transform otherPlayer = GetPlayer.getOtherPlayerByName(gameObject.name);
        if (Mathf.Abs(otherPlayer.position.x - transform.position.x) > 0.05)
            if (otherPlayer.position.x - transform.position.x < 0f)
            {
                if (transform.localScale.x == 1f && rightArmParent.transform.localScale.x == 1)
                {
                    Vector3 scale = rightArmParent.transform.localScale;
                    scale.x = -1f;
                    rightArmParent.transform.localScale = scale;
                }
                else if (transform.localScale.x == -1f)
                {
                    Vector3 scale = rightArmParent.transform.localScale;
                    scale.x = 1f;
                    rightArmParent.transform.localScale = scale;
                }
            }
            else if (otherPlayer.position.x - transform.position.x > 0f)
            {
                if (transform.localScale.x == -1f && rightArmParent.transform.localScale.x == 1f)
                {
                    Vector3 scale = rightArmParent.transform.localScale;
                    scale.x = -1f;
                    rightArmParent.transform.localScale = scale;
                }
                else if (transform.localScale.x == 1f)
                {
                    Vector3 scale = rightArmParent.transform.localScale;
                    scale.x = 1f;
                    rightArmParent.transform.localScale = scale;
                }
            }

        Vector3 eulerAngle = rightArm.transform.localEulerAngles;
        Vector3 localOtherPlayer = (otherPlayer.transform.position - transform.position).normalized;
        float radiansAngle = Mathf.Asin(localOtherPlayer.y / localOtherPlayer.magnitude);
        //float radiansAngle = Mathf.Deg2Rad * Vector3.Angle(transform.forward, (otherPlayer.transform.position - transform.position));
        float a = 90f + radiansAngle * Mathf.Rad2Deg;

        Vector3 position = rightArm.transform.localPosition;
        position.y = Mathf.Sin(radiansAngle) * 0.47f * i / max;
        position.x = Mathf.Cos(radiansAngle) * 0.47f * i / max;
        rightArm.transform.localPosition = position;

        eulerAngle.z = a;
        rightArm.transform.localEulerAngles = eulerAngle;
        
        if (i < max)
        {
            /*localOtherPlayer = localOtherPlayer.normalized;
            localOtherPlayer.x *= transform.localScale.x;
            rightArm.transform.localPosition = new Vector3(
            localOtherPlayer.x * (i + 1) / max,
            localOtherPlayer.y * (i + 1) / max,
            rightArm.transform.localPosition.z);
            SpriteRenderer rightSr = rightArm.GetComponent<SpriteRenderer>();
            rightSr.color = new Color(rightSr.color.r, rightSr.color.g, rightSr.color.b, Mathf.Clamp(1f * (i + 1) / max, 0f, 1f));*/
            i++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, 0.8f);
    }
}
