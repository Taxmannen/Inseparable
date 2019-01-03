using UnityEngine;

/* Script made by Daniel */
public class StartMenu : MonoBehaviour {
    public GameSetup gameSetup;
    MenuManager menuManager;
    GameSettings gs;
    bool enter;
    bool loading;

    private void Start()
    {
        gs = GameObject.Find("Main").GetComponent<GameSettings>();
        menuManager = FindObjectOfType<MenuManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enter && other.isTrigger)
        {
            if (other.name == "Settings Button")
            {
                menuManager.OpenSettingsMenu();
                menuManager.OnMenuChange();
            }
            else if (other.name == "Continue Button" && !loading)
            {
                loading = true;
                gameSetup.Invoke("EnableHud", 0.25f);
                gs.LoadOnContinue();
            }
            else if (other.name == "Exit Button")
            {
                Application.Quit();
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
            if (other.name == "Settings Button") enter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Settings Button") enter = false;        
    }
}
