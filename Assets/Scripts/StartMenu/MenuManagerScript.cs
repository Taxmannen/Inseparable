using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Script made by Michael */
public class MenuManagerScript : MonoBehaviour {
    public GameObject menu;
    public bool toggleMenu;
    public List<GameObject> menus = new List<GameObject>();
    Button curResButton;
    int curRes;

    public AudioSource sound;
    public bool audioOn;

    public float currentMasterVolume;
    public Slider masterVolumeSlider;

    public float currentSoundEffectsVolume;
    public Slider soundEffectsVolumeSlider;

    void Start()
    {
        toggleMenu = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu XBOX"))
        {
            toggleMenu = !toggleMenu;
            menu.SetActive(toggleMenu);

            if (!toggleMenu)
            {
                for (var i = 0; i < menus.Count; i++)
                {
                    menus[i].SetActive(false);
                }
            }
        }

        if (sound != null) sound.volume = currentMasterVolume;
        ChangeMasterVolume();

        if (currentMasterVolume > 0) audioOn = true;
        else                         audioOn = false;
    }

    public void OpenSettingsMenu()
    {
        for (var i = 0; i < menus.Count; i++)
        {
            toggleMenu = !toggleMenu;
            menus[1].SetActive(toggleMenu);
        }
    }

    public void ChangeResolution(int curRes)
    {
        if(curRes == 1920)
        {
            Screen.SetResolution(1920, 1200, true);
            Debug.Log("Changed resolution to " + curRes);
        }
        if (curRes == 1280)
        {
            Screen.SetResolution(1280, 720, true);
            Debug.Log("Changed resolution to " + curRes);
        }
    }

    public void ChangeMasterVolume()
    {
        currentMasterVolume = masterVolumeSlider.value;
    }

    public void ChangeSoundEffectsVolume()
    {
        currentSoundEffectsVolume = soundEffectsVolumeSlider.value;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted Game");
    }
}
