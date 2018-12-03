using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public Canvas canvas;
    public Button controlsButton, generalButton;
    string str;

    // Use this for initialization
    void Start () {
        str = transform.name;

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OpenControlsMenu()
    {

    }

    void OpenGeneralMenu()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log(str);

            if(str == "Settings")
            {
                //Enter settings
                Debug.Log("Entered settings");
            }
            if (str == "Continue")
            {
                //Load most recent game
                Debug.Log("Loaded most recent game");
            }
            if (str == "Exit")
            {
                //Exit game
                Debug.Log("Exited game");
            }
            if (str == "NewGame")
            {
                //New game
                Debug.Log("Started a new game");
            }
        }
    }
}
