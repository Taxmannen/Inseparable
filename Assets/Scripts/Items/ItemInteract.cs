using UnityEngine;

//Made by Jocke
public class ItemInteract : MonoBehaviour {
    GameObject playerUI;
    bool pickedUp;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            playerUI = GameObject.Find(other.name + " " + "UI");
            Inventory inventory = playerUI.GetComponentInChildren<Inventory>();
            if (inventory.PickupItem(gameObject))
            {
                Pickup(other.transform);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                inventory.SwitchItem(gameObject);
                Pickup(other.transform);
            }
        }
    }

    void Pickup(Transform other)
    {
        transform.SetParent(other.GetChild(1));
        pickedUp = true;
    }

    public void DropItem()
    {
        Invoke("SetPickedupState", 0.25f);
    }

    void SetPickedupState()
    {
        pickedUp = false;
    }
}