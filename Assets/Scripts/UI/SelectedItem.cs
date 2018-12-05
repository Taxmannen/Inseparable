using UnityEngine;
using UnityEngine.UI;

//Made by Jocke
public class SelectedItem : MonoBehaviour {
    Image selectedItem;
    Sprite sprite;

    void Start ()
    {
        selectedItem = transform.GetChild(0).GetComponent<Image>();
    }
    
    public void SwapSprite(Sprite sprite)
    {
        selectedItem.sprite = sprite;
    }
}
