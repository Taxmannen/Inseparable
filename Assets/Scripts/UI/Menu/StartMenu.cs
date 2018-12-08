using UnityEngine;

/* Script made by Michael */
public class StartMenu : MonoBehaviour {
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public MenuManager menuScript;
    public GameObject backButton;

    /*private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.tag == "Player")
       {
            if (gameObject.name == "Settings")
            {
                settingsPanel.SetActive(true);
                backButton.SetActive(false);
                menuScript.toggleMenu = true;
            }

            else if (gameObject.name == "Continue")
            {
                Debug.Log("Continue");
            }

            else if (gameObject.name == "Exit")
            {
                Debug.Log("Exit");
            }

            else if (gameObject.name == "Help")
            {
                helpPanel.SetActive(true);
                menuScript.toggleMenu = true;
            }
        }
    }*/
}