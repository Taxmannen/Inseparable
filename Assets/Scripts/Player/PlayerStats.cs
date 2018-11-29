using UnityEngine;
//Made by Jocke
public class PlayerStats : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;


    void Start () {
        currentHealth = maxHealth;	
	}

    private void FixedUpdate()
    {
        CheckHealth();
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

    void CheckHealth()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
}
