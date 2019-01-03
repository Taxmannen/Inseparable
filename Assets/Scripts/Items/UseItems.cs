using UnityEngine;

// Script made by Jocke
public class UseItems : MonoBehaviour {
    [HideInInspector] public Sprite transparent;
    public int healAmount = 100;

    PlayerStats playerStats;
    PlayerStats otherPlayer;
    Inventory inventory;
    SelectedItem selectedItem;

    private void Start()
    {
        GameObject UI = GameObject.Find(gameObject.name + " " + "UI");
        selectedItem = UI.GetComponentInChildren<SelectedItem>();
        inventory = UI.GetComponentInChildren<Inventory>();
        playerStats = GetComponent<PlayerStats>();
        if (gameObject.name == "Player 1") otherPlayer = GameObject.Find("Player 2").GetComponent<PlayerStats>();
        if (gameObject.name == "Player 2") otherPlayer = GameObject.Find("Player 1").GetComponent<PlayerStats>();
    }

    void Update()
    {
        UseItem();
    }

    void UseItem()
    { 
        if (Input.GetButtonDown("Use Item" + " " + gameObject.name))
        {
            if (!selectedItem.GetHealthPotion() && !selectedItem.GetReviveStone())
            {
                AudioManager.Play("NoneItem");
            }

            if (selectedItem.GetHealthPotion() && !playerStats.GetUsePotion())
            {
                AudioManager.Play("CannotUseItem");
            }

            if (selectedItem.GetReviveStone() && !otherPlayer.GetDead())
            {
                AudioManager.Play("CannotUseItem");
            }

            if (selectedItem.GetHealthPotion() && playerStats.GetUsePotion())
            {
                AudioManager.Play("UseItem");
                playerStats.RestoreHealth(healAmount);
                inventory.DestroyItem();
                inventory.InventorySetup();
            }

            if (selectedItem.GetReviveStone() && otherPlayer.GetDead())
            {
                AudioManager.Play("UseItem");
                otherPlayer.Revive(healAmount);
                inventory.DestroyItem();
                inventory.InventorySetup();
            }
        }
    }
}
