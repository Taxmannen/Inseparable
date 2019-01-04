using UnityEngine;

// Script made by Jocke
public class PlayerStats : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;
    public bool dead;
    TakeDamageEffect takeDamageEffect;

    bool usePotion;
    Animator anim;
    MonoBehaviour[] scripts;

    void Start ()
    {
        scripts = gameObject.GetComponents<MonoBehaviour>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        takeDamageEffect = GetComponent<TakeDamageEffect>();
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
            usePotion = true;
            takeDamageEffect.StartFade();
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
            if ((currentHealth + restorHealth) >= maxHealth)
            {
                currentHealth = maxHealth;                
            }
            else currentHealth += restorHealth;
        } 
    }

    void CheckHealth()
    {        
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            usePotion = false;
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
        anim.Play("Death");
    }

    public void Revive(int startHealth)
    {
        dead = false;
        currentHealth = startHealth;
        SetScripts(true);
        anim.Play("Idle");
    }

    void SetScripts(bool state)
    {
        for (int i = 0; i < scripts.Length; i++)
        {
            if (!(scripts[i] is PlayerStats)) scripts[i].enabled = state;
        }
        transform.GetChild(0).gameObject.SetActive(!state);
    }

    public bool GetUsePotion()
    {
        return usePotion;
    }

    public bool GetDead()
    {
        return dead || !gameObject.activeSelf;
    }
}
