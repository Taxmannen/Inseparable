using UnityEngine;

/* Script made by Daniel */
public class DeathArea : MonoBehaviour {

    LevelManager levelManager;
    PlayerStats player1Stats;
    PlayerStats player2Stats;
    bool loading;

    private void Start()
    {
        levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
    }

    private void Update()
    { 
        if (Input.GetButtonDown("Inventory Player 1")) levelManager.Load("Level 1");
        if (player1Stats.dead && player2Stats.dead && !loading)
        {
            loading = true;
            levelManager.Load("Level 1");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerStats>().TakeHealth(100000);
    }
}