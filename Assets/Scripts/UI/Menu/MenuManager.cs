using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Script made by Michael */
public class MenuManager : MonoBehaviour {
    public List<GameObject> menus = new List<GameObject>();
    public GameObject menu;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;
    public AudioMixer mixer;
    public bool toggleMenu;

    string player1Button;
    string player2Button;
    int curRes;

    void Start()
    {
        player1Button = "Menu" + " " + "Player 1" + " " + Main.controllers[0];
        player2Button = "Menu" + " " + "Player 2" + " " + Main.controllers[1];
        toggleMenu = false;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            if (Input.GetButtonDown(player1Button) || Input.GetButtonDown(player2Button))
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
        }
    }

    public void OpenSettingsMenu()
    {
        for (var i = 0; i < menus.Count; i++)
        {
            toggleMenu = !toggleMenu;
            menus[1].SetActive(toggleMenu);
        }
    }

    private void ChangeResolution(int curRes)
    {
        if      (curRes == 1920) Screen.SetResolution(1920, 1200, true);
        else if (curRes == 1280) Screen.SetResolution(1280, 720, true);
        Debug.Log("Changed resolution to" + " " + curRes);
    }

    public void ChangeMasterVolume()
    {
        mixer.SetFloat("MasterVol", masterVolumeSlider.value);
    }

    public void ChangeSFXVolume()
    {
        mixer.SetFloat("SFXVol", soundEffectsVolumeSlider.value);
    }

    public void ChangeMusicVolume()
    {
        mixer.SetFloat("MusicVol", musicVolumeSlider.value);
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
