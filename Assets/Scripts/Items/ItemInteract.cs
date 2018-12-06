using UnityEngine;
//Made by Jocke
public class ItemInteract : MonoBehaviour
{
    GameObject playerUI;
    public Sprite item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerUI = GameObject.Find(other.name + " " + "UI");
            playerUI.GetComponentInChildren<Inventory>().CheckItemSlot();
            if (playerUI.GetComponentInChildren<Inventory>().GetIsItemSlotEmpty())
            {
                playerUI.GetComponentInChildren<Inventory>().PickupItem(item);
                Destroy(gameObject);
            }
        }
    }
}