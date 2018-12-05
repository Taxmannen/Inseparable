using UnityEngine;
using UnityEngine.UI;

//Made by Jocke
public class SelectedItem : MonoBehaviour {
    public Image selectedItem;

    void Start ()
    {
        selectedItem = transform.GetChild(0).GetComponent<Image>();
    }
    
    public void SwapSprite(Sprite sprite)
    {
        if (selectedItem != null) selectedItem.sprite = sprite;
    }
}
