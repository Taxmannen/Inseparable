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
        setAlpha(0);
        images = new Image[numberOfItems];
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            images[i] = transform.GetChild(0).GetChild(i).GetComponent<Image>();
        }
    }

    private void Update()
    {
       if (timer > 0)
        {
            timer -= Time.deltaTime;
            setAlpha(timer);
        }

        if (Input.GetButtonDown("Change Item Player " + player))
        {
            if (Input.GetAxisRaw("Change Item Player " + player) > 0) PositiveItemSwap();
            if (Input.GetAxisRaw("Change Item Player " + player) < 0) NegativeItemSwap();
        }
    }

    private void PositiveItemSwap()
    {
        timer = 2;
        setAlpha(timer);

        Sprite tmp = images[0].sprite;
        images[0].sprite = images[2].sprite;
        images[2].sprite = images[1].sprite;
        images[1].sprite = tmp;
        selectedItem.SwapSprite(images[0].sprite);
    }

    private void NegativeItemSwap()
    {
        timer = 2;
        setAlpha(timer);

        Sprite tmp = images[0].sprite;
        images[0].sprite = images[1].sprite;
        images[1].sprite = images[2].sprite;
        images[2].sprite = tmp;
        selectedItem.SwapSprite(images[0].sprite);
    }

    public void setAlpha(float alpha) {
        CanvasRenderer[] children = transform.GetChild(0).GetComponentsInChildren<CanvasRenderer>();
            foreach (CanvasRenderer child in children)
            {
                child.SetAlpha(alpha);
            }
    }
}
