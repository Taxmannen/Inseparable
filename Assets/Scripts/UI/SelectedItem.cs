using UnityEngine;
using UnityEngine.UI;
//Made by Jocke
public class SelectedItem : MonoBehaviour {
    Image selectedItem;
    Sprite sprite;
	void Start () {
        selectedItem = GetComponent <Image>();
        
    }

    private void Update()
    {
        SwapSprite(sprite);
    }

    public void SwapSprite(Sprite sprite)
    {
        selectedItem.sprite = this.sprite;
    }
}
