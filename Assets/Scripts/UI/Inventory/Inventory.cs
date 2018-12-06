using UnityEngine;
using UnityEngine.UI;

// Made by Jocke
public class Inventory : MonoBehaviour {
    public float fadeSpeed = 5f;
    public SelectedItem selectedItem;
    public Sprite empty;
    public string player;
    bool isItemSlotEmpty;
    bool setFadeEffect;
    
    Image[] images;
    CanvasRenderer bg;
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
        CalculateFadeEffect();
        if (Input.GetButtonDown("Change Item Player " + player))
        {
            if (Input.GetAxisRaw("Change Item Player " + player) > 0) NegativeItemSwap();
            if (Input.GetAxisRaw("Change Item Player " + player) < 0) PositiveItemSwap();
        }
    }

    private void PositiveItemSwap()
    {
        setFadeEffect = true;
        Sprite tmp = images[1].sprite;
        images[1].sprite = images[0].sprite;
        images[0].sprite = images[2].sprite;
        images[2].sprite = tmp;
        selectedItem.SwapSprite(images[1].sprite);
    }

    private void NegativeItemSwap()
    {
        setFadeEffect = true;
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

        if (bg == null) bg = GetComponent<CanvasRenderer>();
        bg.SetAlpha(alpha);
        if (alpha > 0.75f) bg.SetAlpha(0.75f);
    }

    public void PickupItem(Sprite s) 
    {
        foreach (Image i in images)
        {
            if (i.sprite == empty)
            {
                i.sprite = s;
                if (selectedItem.selectedItem.sprite == empty) selectedItem.SwapSprite(s);
                isItemSlotEmpty = false;
                return;
            }
        }
    }

    //TODO För byte av item
    public void SwitchItem(Sprite s)
    {
        images[1].sprite = s;
    }

    public void CheckItemSlot()
    {
        foreach (Image i in images)
        {
            if (i.sprite == empty) isItemSlotEmpty = true;
        }
    }

    public bool GetIsItemSlotEmpty()
    {
        return isItemSlotEmpty;
    }

    public void CalculateFadeEffect()
    {
        if (timer > 2)
        {
            setFadeEffect = false;
        }

        if (setFadeEffect)
        {
            timer += Time.deltaTime;
            SetAlpha(timer * fadeSpeed);
        }

        if (!setFadeEffect && timer > 0)
        {
            timer -= Time.deltaTime;
            SetAlpha(timer * fadeSpeed);
        }
    }

    public void SetSpriteInImages(Sprite s)
    {
        images[1].sprite = s;
    }
}
