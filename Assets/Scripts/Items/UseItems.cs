using UnityEngine;

//Made by Jocke
public class UseItems : MonoBehaviour {
    [HideInInspector] public Sprite transparent;
    public int healAmount = 100;

    PlayerStats playerStats;
    PlayerStats otherPlayer;
    SelectedItem selectedItem;

    private void Start()
    {
        GameObject UI = GameObject.Find(gameObject.name + " " + "UI");
        selectedItem = UI.GetComponentInChildren<SelectedItem>();

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
            if (selectedItem.GetHealthPot() && playerStats.GetUsePotion()) playerStats.RestoreHealth(healAmount);
            else if (selectedItem.GetReviveStone() && otherPlayer.GetDead()) otherPlayer.Revive(healAmount);

            selectedItem.SwapSprite(transparent);
            //TA BORT FRÅN LISTAN!
        }
    }
}
