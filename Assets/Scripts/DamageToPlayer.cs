using UnityEngine;

public class DamageToPlayer : MonoBehaviour {
    public int damage;
    public float damageRate;

    PlayerStats player1Stats;
    PlayerStats player2Stats;
    bool player1;
    bool player2;
    float timer;

    void Start()
    {
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
    }

    void Update()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if      (other.name == "Player 1") player1 = true;
        else if (other.name == "Player 2") player2 = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if      (other.name == "Player 1") player1 = false;
        else if (other.name == "Player 2") player2 = false;
    }
}