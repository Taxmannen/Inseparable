using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    public Inventory inventory;
    public Sprite item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            /*for( int i = 0; i < inventory.images.Length; i++)
            {
                if(inventory.images[i] == null)
                {
                    Debug.Log("HEEEJ");
                }
            }    */
        }
    }
}