﻿using UnityEngine;
using UnityEngine.UI;
//Made by Jocke
public class SelectedItem : MonoBehaviour {
    Image selectedItem;
    Sprite sprite;


    void Start () {
        selectedItem = transform.GetComponent <Image>();
        //Debug.Log(transform.parent.name);
        
    }
    
    public void SwapSprite(Sprite sprite)
    {
        selectedItem.sprite = sprite;
    }
}
