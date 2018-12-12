using UnityEngine;
using UnityEngine.UI;

//Made by Jocke
public class SelectedItem : MonoBehaviour {
    public Image selectedItem;
    bool healthPotion;
    bool reviveStone;

    void Start ()
    {
        selectedItem = transform.GetChild(0).GetComponent<Image>();
    }
    
    public void SwapSprite(Sprite s)
    {
        if (selectedItem != null) selectedItem.sprite = s;
        CheckUsebleItem(s.name);
    }

    public void CheckUsebleItem(string s)
    {
       healthPotion = s == "Potion" ? true : false;
       reviveStone = s == "Revive" ? true : false;
    }

    public bool GetHealthPotion()
    {
        return healthPotion;
    }

    public bool GetReviveStone()
    {
        return reviveStone;
    }
}
