using UnityEngine;

//Made by Jocke
public class ItemInteract : MonoBehaviour
{
    GameObject playerUI;
    public GameObject[] items;
    private void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            playerUI = GameObject.Find(other.name + " " + "UI");
            Inventory inventory = playerUI.GetComponentInChildren<Inventory>();
            if (inventory.PickupItem(gameObject));
        }
    }
}