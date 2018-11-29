using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;


    void Start () {
        currentHealth = maxHealth;	
	}

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void RestorHealth(int restorHealth)
    {
        if(currentHealth + restorHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else currentHealth += restorHealth;
    }

    void Die()
    {
        Debug.Log("You are dead Mother Fucker");
    }
}
