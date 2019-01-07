using UnityEngine;
using UnityEngine.UI;

// Script made by Jocke
public class PlayerHealthBar : MonoBehaviour {
    public Slider healthBar;

    PlayerStats playerStats;

    void Start ()
    {
        if      (gameObject.name.Contains("1")) playerStats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        else if (gameObject.name.Contains("2")) playerStats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
     
        healthBar.maxValue = playerStats.maxHealth;
        healthBar.value = playerStats.currentHealth;
	}

    private void Update()
    {
        if (playerStats == null)
        {
            if      (gameObject.name.Contains("1") && GameObject.Find("Player 1") != null) playerStats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
            else if (gameObject.name.Contains("2") && GameObject.Find("Player 2") != null) playerStats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
        }
        healthBar.value = playerStats.currentHealth;
    }
}
