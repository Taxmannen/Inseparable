using UnityEngine;

/* Script made by Michael */
public class WorldMenuScript : MonoBehaviour {
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public GameObject aboutPanel;
    public MenuManagerScript menuScript;

    public GameObject backButton;
    private bool openedFromWorldMenu;


    /*private void OnTriggerEnter2D(Collider2D col)
    {
       /*if (col.tag == "Player")
        {
            if (this.tag == "SettingsTag")
            {
                Debug.Log("Entered " + this.tag);
                settingsPanel.SetActive(true);
                backButton.SetActive(false);
                menuScript.toggleMenu = true;

            }
            if (this.tag == "HelpTag")
            {
                Debug.Log("Entered " + this.tag);
                helpPanel.SetActive(true);
                menuScript.toggleMenu = true;
            }
            if (this.tag == "AboutTag")
            {
                Debug.Log("Entered " + this.tag);
                aboutPanel.SetActive(true);
                menuScript.toggleMenu = true;
            }
            if (this.tag == "NewGameTag")
            {
                Debug.Log("Entered " + this.tag);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (this.tag == "SettingsTag")
            {
                Debug.Log("Left " + this.tag);
                settingsPanel.SetActive(false);
                backButton.SetActive(true);
                menuScript.toggleMenu = false;

            }
            if (this.tag == "HelpTag")
            {
                Debug.Log("Left " + this.tag);
                helpPanel.SetActive(false);
                menuScript.toggleMenu = false;
            }
            if (this.tag == "AboutTag")
            {
                Debug.Log("Left " + this.tag);
                aboutPanel.SetActive(false);
                menuScript.toggleMenu = false;
            }
            if (this.tag == "NewGameTag")
            {
                Debug.Log("Left " + this.tag);
            }
        }
    }*/
}
