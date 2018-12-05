using UnityEngine;
using UnityEngine.UI;

// Made by Jocke
public class PlayerHealth : MonoBehaviour {
    public PlayerStats playerStats;
    public Slider healthBar;


    void Start () {
        healthBar.maxValue = playerStats.maxHealth;
        healthBar.value = playerStats.currentHealth;
	}

    private void Update()
    {
        if (playerStats == null)
        {
            if      (gameObject.name.Contains("1")) playerStats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
            else if (gameObject.name.Contains("2")) playerStats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
        }
        healthBar.value = playerStats.currentHealth;
    }
}
