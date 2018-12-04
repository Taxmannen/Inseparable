using UnityEngine;
using UnityEngine.UI;
// Made by Jocke
public class Inventory : MonoBehaviour {
    public SelectedItem selectedItem;
    Image[] images;
    float timer;
    public string player;
    int numberOfItems = 3;


    private void Start()
    {
        images = new Image[numberOfItems];
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            images[i] = transform.GetChild(0).GetChild(i).GetComponent<Image>();
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
       if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Change Item Player " + player))
        {
            if (Input.GetAxisRaw("Change Item Player " + player) > 0) PositiveItemSwap();
            if (Input.GetAxisRaw("Change Item Player " + player) < 0) NegativeItemSwap();
        }
    }

    private void PositiveItemSwap()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        timer = 3;
        Sprite tmp = images[0].sprite;
        images[0].sprite = images[2].sprite;
        images[2].sprite = images[1].sprite;
        images[1].sprite = tmp;
        selectedItem.SwapSprite(images[0].sprite);
    }

    private void NegativeItemSwap()
    {
        timer = 3;
        transform.GetChild(0).gameObject.SetActive(true);
        float tmpTimer = timer;
        Sprite tmp = images[0].sprite;
        images[0].sprite = images[1].sprite;
        images[1].sprite = images[2].sprite;
        images[2].sprite = tmp;
        selectedItem.SwapSprite(images[0].sprite);
    }

    /*public void setAlpha(float alpha) {
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
            Color newColor;
            foreach (SpriteRenderer child in children)
            {
                newColor = child.color; newColor.a = alpha; child.color = newColor;
            }
    }*/
}
