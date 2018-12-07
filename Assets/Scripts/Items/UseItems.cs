using UnityEngine;

//Made by Jocke
public class UseItems : MonoBehaviour {
    public int healAmount = 100;
    public Sprite transparent;

    PlayerStats playerStats;
    PlayerStats otherPlayer;
    SelectedItem selectedItem;
    Inventory inventory;

    private void Start()
    {
        GameObject UI = GameObject.Find(gameObject.name + " " + "UI");
        selectedItem = UI.GetComponentInChildren<SelectedItem>();
        inventory    = UI.GetComponentInChildren<Inventory>();

        playerStats = GetComponent<PlayerStats>();

        if (gameObject.name == "Player 1") otherPlayer = GameObject.Find("Player 2").GetComponent<PlayerStats>();
        if (gameObject.name == "Player 2") otherPlayer = GameObject.Find("Player 1").GetComponent<PlayerStats>();
    }

    void Update()
    {
        UseItem();

        if (Input.GetButtonDown("Seperate Player 1")) playerStats.TakeHealth(100);
    }

    void UseItem()
    { 
        if (Input.GetButtonDown("Use Item" + " " + gameObject.name))
        {
            if (selectedItem.GetHealthPot() && playerStats.GetUsePotion()) playerStats.RestoreHealth(healAmount);
            else if (selectedItem.GetReviveStone() && otherPlayer.GetDead()) otherPlayer.Revive(healAmount);

            selectedItem.SwapSprite(transparent);
            inventory.SetSpriteInImages(transparent);
        }
    }
}
