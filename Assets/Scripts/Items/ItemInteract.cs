using UnityEngine;

//Made by Jocke
public class ItemInteract : MonoBehaviour {
    GameObject playerUI;
    bool pickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !pickedUp)
        {
            playerUI = GameObject.Find(other.name + " " + "UI");
            Inventory inventory = playerUI.GetComponentInChildren<Inventory>();
            if (inventory.PickupItem(gameObject)) transform.SetParent(other.transform.GetChild(1));
            pickedUp = true;
        }
    }
}