using UnityEngine;
using UnityEngine.UI;

// Script made by Jocke
public class Inventory : MonoBehaviour {
    public float fadeSpeed = 5f;
    public SelectedItem selectedItem;
    public GameObject[] items;
    public Sprite empty;
    public string player; //FIXA!!!

    bool setFadeEffect;
    public bool SwitchItemBool { get; private set; }

    Image[] images = new Image[3];
    CanvasRenderer bg;
    float timer;
    readonly int numberOfItems = 3;

    private void Start()
    {
        images = new Image[numberOfItems];
        SetAlpha(0);
        InventorySetup();
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


    public bool PickupItem(GameObject item)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                InventorySetup();
                //SÄTT NYA ITEMET TILL SELECTED!?!?
                return true;
            }
        }
        return false;
    }

    public void DropItem(GameObject item)
    {
        item.transform.SetParent(null);
        item.GetComponent<ItemInteract>().DropItem();
    }

    public void DestroyItem()
    {
        images[1].sprite = empty;
        items[1] = null;
    }

    public void SwitchItem(GameObject item)
    {
        DropItem(items[1]);
        items[1] = item;
        InventorySetup();
    }

    public void InventorySetup()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            images[i] = transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>();
            if (items[i] != null)
                images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            else
                images[i].sprite = empty;
        }
        selectedItem.SwapSprite(images[1].GetComponent<Image>().sprite);
    }

    private void PositiveItemSwap()
    {
        setFadeEffect = true;
        GameObject tmp = items[1];
        items[1] = items[0];
        items[0] = items[2];
        items[2] = tmp;
        InventorySetup();
    }

    private void NegativeItemSwap()
    {
        setFadeEffect = true;
        GameObject tmp = items[0];
        items[0] = items[1];
        items[1] = items[2];
        items[2] = tmp;
        InventorySetup();
    }

    public void SetAlpha(float alpha)
    {
        CanvasRenderer[] children = transform.GetChild(0).GetComponentsInChildren<CanvasRenderer>();
        foreach (CanvasRenderer child in children) child.SetAlpha(alpha);

        if (bg == null) bg = GetComponent<CanvasRenderer>();
        bg.SetAlpha(alpha);
        if (alpha > 0.75f) bg.SetAlpha(0.75f);
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
}
