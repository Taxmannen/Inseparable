using UnityEngine;
using UnityEngine.UI;

//Made by Jocke
public class SelectedItem : MonoBehaviour {
    public Image selectedItem;
    bool healthPot;

    void Start ()
    {
        selectedItem = transform.GetChild(0).GetComponent<Image>();
    }
    
    public void SwapSprite(Sprite sprite)
    {
        if (selectedItem != null) selectedItem.sprite = sprite;
        CheckUsebleItem(sprite.name);
    }

    public void CheckUsebleItem(string s)
    {
       healthPot = s == "Potion" ? true : false;
    }

    public bool GetHealthPot()
    {
        return healthPot;
    }
}
