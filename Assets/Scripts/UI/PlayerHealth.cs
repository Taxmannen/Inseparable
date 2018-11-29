using UnityEngine;
using UnityEngine.UI;
// Made by Jocke
public class PlayerHealth : MonoBehaviour {
    
    public Slider healthBar;
    public float CurrentHealth;
    public float MaxHealth;


    void Start () {
        healthBar.maxValue = MaxHealth;
        healthBar.value = CurrentHealth;
	}

    private void Update()
    {
        healthBar.value = CurrentHealth;
    }
}
