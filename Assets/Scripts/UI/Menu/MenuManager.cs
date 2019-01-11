using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* Script made by Michael */
public class MenuManager : MonoBehaviour {
    public List<GameObject> menus = new List<GameObject>();
    public GameObject mainMenu;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;
    public EventSystem eventSystem;
    public AudioMixer mixer;
    public bool toggleMenu;
    public GameObject settingsBackButton;

    string player1Button;
    string player2Button;
    GameObject firstButton;

    void Start()
    {
        player1Button = "Menu" + " " + "Player 1" + " " + "XBOX";
        toggleMenu = false;
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolumeSlider.value  = PlayerPrefs.GetFloat("MusicVolume");
        soundEffectsVolumeSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume");

        if (PlayerPrefs.GetInt("CurrentResolution1") == 0 && PlayerPrefs.GetInt("CurrentResolution2") == 0)
        {
            Screen.SetResolution(1920, 1200, true);
        }
        else Screen.SetResolution(PlayerPrefs.GetInt("CurrentResolution1"), PlayerPrefs.GetInt("CurrentResolution2"), true);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            if (Input.GetButtonDown(player1Button)) SetMenuState();
            {
                settingsBackButton.SetActive(true);
            }
        }
        else
        {
            if (mainMenu.activeSelf)
            {
                mainMenu.SetActive(false);
                toggleMenu = false;          
            }
        }

        for(int i = 0; i < menus.Count; i++)
        {
            if (toggleMenu)
            {
                if (Input.GetButtonDown("Submit Player 1"))
                {
                    AudioManager.PlayOneShot("MenuSubmit");
                }
                if (Input.GetButtonDown("Cancel Player 1"))
                {
                    AudioManager.Play("MenuCancel");
                }
                if (Input.GetButtonDown("Vertical Player 1"))
                {
                    AudioManager.Play("MenuUpAndDown");
                }
            }
        }
    }

    public void OpenSettingsMenu()
    {
        for (var i = 0; i < menus.Count; i++)
        {
            toggleMenu = !toggleMenu;
            menus[1].SetActive(true);
        }
        if (SceneManager.GetActiveScene().name.Contains("Level")) settingsBackButton.SetActive(true);
        else
        {
            settingsBackButton.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void ChangeResolution(int curRes)
    {
        if (curRes == 1920)
        {
            Screen.SetResolution(1920, 1200, true);
            PlayerPrefs.SetInt("CurrentResolution1", 1920);
            PlayerPrefs.SetInt("CurrentResolution2", 1200);
        }
        else if (curRes == 1280)
        {
            Screen.SetResolution(1280, 720, true);
            PlayerPrefs.SetInt("CurrentResolution1", 1280);
            PlayerPrefs.SetInt("CurrentResolution2", 720);
        }
    }

    public void ChangeMasterVolume()
    {
        mixer.SetFloat("MasterVol", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void ChangeSFXVolume()
    {
        mixer.SetFloat("SFXVol", soundEffectsVolumeSlider.value);
        PlayerPrefs.SetFloat("SoundEffectsVolume", soundEffectsVolumeSlider.value);
    }

    public void ChangeMusicVolume()
    {
        mixer.SetFloat("MusicVol", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void OnMenuChange()
    {
        eventSystem.SetSelectedGameObject(null);
        foreach (GameObject menu in menus)
        {
            if (menu.activeSelf)
            {
                foreach (Transform button in menu.transform)
                {
                    if (button.GetComponent<Button>() != null || button.GetComponent<Slider>() != null)
                    {
                        firstButton = button.gameObject;
                        eventSystem.SetSelectedGameObject(firstButton);
                        return;
                    }
                }
            }
        }
    }

    public void SetMenuState()
    {
        toggleMenu = !toggleMenu;
        mainMenu.SetActive(toggleMenu);
        OnMenuChange();

        if (!toggleMenu)
        {
            for (var i = 0; i < menus.Count; i++)
            {
                menus[i].SetActive(false);               
            }
        }
        if (toggleMenu) Time.timeScale = 0;
        else            Time.timeScale = 1; 
    }

    public void SetTimeScale()
    {
        Time.timeScale = 1;
    }
}