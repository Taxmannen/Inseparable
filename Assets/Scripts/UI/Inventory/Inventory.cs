using UnityEngine;
using UnityEngine.UI;

// Made by Jocke
public class Inventory : MonoBehaviour {
    public float fadeSpeed = 5f;
    public SelectedItem selectedItem;
    public Sprite empty;
    public string player;

    Image[] images;
    float timer;
    readonly int numberOfItems = 3;

    private void Start()
    {
        SetAlpha(0);
        images = new Image[numberOfItems];
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            images[i] = transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>();
        }
        selectedItem.SwapSprite(images[1].sprite);
    }

    private void Update()
    {
       if (timer > 0)
        {
            timer -= Time.deltaTime;
            SetAlpha(timer * fadeSpeed);
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
        SetAlpha(timer);

        Sprite tmp = images[1].sprite;
        images[1].sprite = images[0].sprite;
        images[0].sprite = images[2].sprite;
        images[2].sprite = tmp;
        selectedItem.SwapSprite(images[1].sprite);
    }

    private void NegativeItemSwap()
    {
        timer = 2;
        SetAlpha(timer);

        Sprite tmp = images[0].sprite;
        images[0].sprite = images[1].sprite;
        images[1].sprite = images[2].sprite;
        images[2].sprite = tmp;
        selectedItem.SwapSprite(images[1].sprite);
    }

    public void SetAlpha(float alpha)
    {
        CanvasRenderer[] children = transform.GetChild(0).GetComponentsInChildren<CanvasRenderer>();
        foreach (CanvasRenderer child in children) child.SetAlpha(alpha);
    }

    //För automatisk pickup
    public void PickupItem(Sprite s) 
    {
        foreach (Image i in images)
        {
            if (i.sprite == empty)
            {
                Debug.Log(i.name + " " + "Empty");
                i.sprite = s;
                //Break
            }
        }
    }

    //För byte av item
    public void SwitchItem(Sprite s)
    {
        images[1].sprite = s;
    }
}
