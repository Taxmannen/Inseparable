using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour {

    public GameObject menu;
    public bool toggleMenu;
    public List<GameObject> menus = new List<GameObject>();
    GameObject backButton;

    void Start()
    {
        toggleMenu = false;
        backButton = GameObject.Find("SettingsBackButton");
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu") )
        {
            toggleMenu = !toggleMenu;
            menu.SetActive(toggleMenu);
            

            if (!toggleMenu)
            {
                for(var i = 0; i < menus.Count; i++)
                {
                    menus[i].SetActive(false);
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenSettingsMenu();
        }
    }


    void OpenSettingsMenu()
    {
        for (var i = 0; i < menus.Count; i++)
        {
            toggleMenu = !toggleMenu;
            menus[1].SetActive(toggleMenu);

        }
    }

}
