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
        healthBar.value = playerStats.currentHealth;
    }
}
