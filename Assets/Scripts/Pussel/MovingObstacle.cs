﻿using UnityEngine;

/* Script made by Daniel */
public class MovingObstacle : MonoBehaviour {
    public int damage;
    public float damageRate;
    public float endPosX;
    public float speed;
    public bool on;
    public bool drawGizmos;
    public Vector2 offset;

    Vector2 endPos;
    CameraManager cameraManager;
    SpriteRenderer sr;
    BoxCollider2D col;
    PlayerStats player1Stats;
    PlayerStats player2Stats;
    bool player1;
    bool player2;
    float timer;

    private void Start()
    {
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();

        sr  = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>(); 

        sr.enabled = false;
        col.enabled = false;

        endPos = new Vector2(endPosX, transform.position.y);
    }

    void FixedUpdate()
    {
        if (on)
        {
            if (!sr.enabled) sr.enabled = true;
            if (!col.enabled) col.enabled = true;

            timer -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed / 100);

            if (player1 || player2)
            {
                if (timer <= 0)
                {
                    if (player1) player1Stats.TakeHealth(damage);
                    if (player2) player2Stats.TakeHealth(damage);
                    timer = damageRate;
                }
            }
            if (Vector3.Distance(transform.position, endPos) < 0.1f) TurnOff();
        }
        else if (!on && player1Stats.transform.position.x > transform.position.x + (transform.localScale.x / 2) && player2Stats.transform.position.x > transform.position.x + (transform.localScale.x / 2))
        {
            Invoke("TurnOn", 1);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player 1") player1 = true;
        if (other.name == "Player 2") player2 = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player 1") player1 = false;
        if (other.name == "Player 2") player2 = false;
    }

    void TurnOn()
    {
        on = true;
        cameraManager = Camera.main.GetComponent<CameraManager>();
        cameraManager.ChangeFocusTo(transform, offset);
    }

    void TurnOff()
    {
        cameraManager.ResetFocus();
        Destroy(this);
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos) Gizmos.DrawCube(new Vector2(endPosX, transform.position.y), transform.localScale);
    }
}
