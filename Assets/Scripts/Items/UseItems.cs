using UnityEngine;
//Made by Jocke
public class UseItems : MonoBehaviour {
    public int healAmount = 100;

    PlayerStats player1Stats;
    PlayerStats player2Stats;
    SelectedItem selectedItemPlayer1;
    SelectedItem selectedItemPlayer2;
    Inventory inventoryPlayer1;
    Inventory inventoryPlayer2;
    public Sprite transparent;
    
    private void Start()
    {
        player1Stats = GameObject.Find("Player 1").GetComponent<PlayerStats>();
        player2Stats = GameObject.Find("Player 2").GetComponent<PlayerStats>();
        selectedItemPlayer1 = GameObject.Find("Player 1 UI").GetComponentInChildren<SelectedItem>();
        selectedItemPlayer2 = GameObject.Find("Player 2 UI").GetComponentInChildren<SelectedItem>();
        inventoryPlayer1 = GameObject.Find("Player 1 UI").GetComponentInChildren<Inventory>();
        inventoryPlayer2 = GameObject.Find("Player 2 UI").GetComponentInChildren<Inventory>();
    }

    void Update()
    {
        UseItemPlayer1();
        UseItemPlayer2();
    }

    void UseItemPlayer1()
    {
        if (Input.GetButtonDown("Use Item Player 1"))
        {
            if (selectedItemPlayer1.GetHealthPot() && player1Stats.GetUsePotion())
            {
                player1Stats.RestoreHealth(healAmount);
                selectedItemPlayer1.SwapSprite(transparent);
                inventoryPlayer1.SetSpriteInImages(transparent);
            }

            if (selectedItemPlayer1.GetReviveStone() && player2Stats.GetDead())
            {
                player2Stats.Revive(healAmount);
                selectedItemPlayer1.SwapSprite(transparent);
                inventoryPlayer1.SetSpriteInImages(transparent);
            }
        }
    }

    void UseItemPlayer2()
    {
        if (Input.GetButtonDown("Use Item Player 2"))
        {
            if (selectedItemPlayer2.GetHealthPot() && player2Stats.GetUsePotion())
            {
                player2Stats.RestoreHealth(healAmount);
                selectedItemPlayer2.SwapSprite(transparent);
                inventoryPlayer2.SetSpriteInImages(transparent);
            }

            if (selectedItemPlayer2.GetReviveStone() && player1Stats.GetDead())
            {
                player1Stats.Revive(healAmount);
                selectedItemPlayer2.SwapSprite(transparent);
                inventoryPlayer2.SetSpriteInImages(transparent);
            }
        }
    }
}
