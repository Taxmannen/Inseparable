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

    public void TakeHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void RestoreHealth(int restorHealth)
    {
        if (currentHealth + restorHealth > maxHealth)
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
