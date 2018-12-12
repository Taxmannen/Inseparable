using UnityEngine;
using UnityEngine.UI;

//Made by Jocke
public class SelectedItem : MonoBehaviour {
    public Image selectedItem;
    bool healthPot;
    bool reviveStone;

    void Start ()
    {
        selectedItem = transform.GetChild(0).GetComponent<Image>();
    }
    
    public void SwapSprite(Sprite s)
    {
        selectedItem.sprite = s;
        //CheckUsebleItem(item.name);
    }

    public void CheckUsebleItem(string s)
    {
       healthPot = s == "Potion" ? true : false;
       reviveStone = s == "Revive" ? true : false;
    }

    public bool GetHealthPot()
    {
        return healthPot;
    }

    public bool GetReviveStone()
    {
        return reviveStone;
    }
}
