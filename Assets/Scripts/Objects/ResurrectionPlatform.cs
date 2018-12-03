using UnityEngine;

/* Script made by Daniel */
public class ResurrectionPlatform : MonoBehaviour {
    public int healthAmount;
    public float healthRate;

    PlayerStats player1Stats;
    PlayerStats player2Stats;
    bool player1;
    bool player2;
    float timer;

    private void Start()
    {
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        //TODO: Resurrect Dead Player!
        timer -= Time.deltaTime;
        if (player1 || player2)
        {
            if (timer <= 0)
            {
                if (player1) player1Stats.RestoreHealth(healthAmount);
                if (player2) player2Stats.RestoreHealth(healthAmount);
                timer = healthRate;
            }   
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
}
