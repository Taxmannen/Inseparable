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
            if      (gameObject.name.Contains("One")) playerStats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
            else if (gameObject.name.Contains("Two")) playerStats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
        }
        healthBar.value = playerStats.currentHealth;
    }
}
