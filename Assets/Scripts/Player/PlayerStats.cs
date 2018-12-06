using UnityEngine;

//Made by Jocke
public class PlayerStats : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;
    public bool dead;

    MonoBehaviour[] scripts;

    void Start ()
    {
        scripts = gameObject.GetComponents<MonoBehaviour>();
        currentHealth = maxHealth;	
	}

    private void FixedUpdate()
    {
        CheckHealth();
    }

    public void TakeHealth(int damage)
    {
        if (!dead)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }
    }

    public void RestoreHealth(int restorHealth)
    {
        if (!dead)
        {
            if (currentHealth + restorHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else currentHealth += restorHealth;
        } 
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

    //Following scritps by Daniel
    void Die()
    {
        dead = true;
        SetScripts(false);
    }

    public void Revive(int startHealth)
    {
        dead = false;
        currentHealth = startHealth;
        SetScripts(true);
    }

    void SetScripts(bool state)
    {
        for (int i = 0; i < scripts.Length; i++)
        {
            if (!(scripts[i] is PlayerStats)) scripts[i].enabled = state;
        }
        transform.GetChild(0).gameObject.SetActive(!state);
    }
}
