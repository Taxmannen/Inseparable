using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Main : MonoBehaviour
{

    public PlayerController player1, player2;
    public TextMeshProUGUI tmp1, tmp2;
    public CameraManager cameraManager;
    bool player1Ready, player2Ready;

    public bool enabledMenu;

    void Start()
    {
        Application.targetFrameRate = 60;
        if(enabledMenu)
        {
            player1.GetComponent<Renderer>().enabled = false;
            player2.GetComponent<Renderer>().enabled = false;
            player1.enabled = false;
            player2.enabled = false;

            cameraManager.enabled = false;

            player1Ready = false;
            player2Ready = false;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Cancel")) SceneManager.LoadScene(SceneManager.GetActiveScene().name); // For Debug!

        if (enabledMenu)
        {
            if (Input.GetButton("Jump " + player1.name))
            {
                tmp1.text = "Player 1 ready!";
                player1Ready = true;
                player1.GetComponent<Renderer>().enabled = true;
                player1.enabled = true;
            }

            if (Input.GetButton("Jump " + player2.name))
            {
                tmp2.text = "Player 2 ready!";
                player2Ready = true;
                player2.GetComponent<Renderer>().enabled = true;
                player2.enabled = true;
            }
        }
    }
}