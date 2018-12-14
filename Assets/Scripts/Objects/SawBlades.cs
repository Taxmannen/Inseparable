using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made by Jocke
public class SawBlades : MonoBehaviour {
    public int damage;
    public float damageRate;
    float timer;
    PlayerStats player1Stats;
    PlayerStats player2Stats;
    bool player1;
    bool player2;


    void Start()
    {
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        DamageToPlayer();

    }

    void DamageToPlayer()
    {
        timer -= Time.deltaTime;
        if (player1 || player2)
        {
            if (timer <= 0)
            {
                if (player1) player1Stats.TakeHealth(damage);
                if (player2) player2Stats.TakeHealth(damage);
                timer = damageRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            if (other.name == "Player 1") player1 = true;
            if (other.name == "Player 2") player2 = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            if (other.name == "Player 1") player1 = false;
            if (other.name == "Player 2") player2 = false;
        }
        
    }
}
