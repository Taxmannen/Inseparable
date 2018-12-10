using UnityEngine;

/* Script made by Daniel */
public class StartMenuManager : MonoBehaviour {
    bool enter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enter && other.isTrigger)
        {
            if (other.name == "Settings Button")
            {
                Debug.Log("Setings - Enter");
            }
            else if (other.name == "Continue Button")
            {
                Debug.Log("Load Latest Save");
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
        if (other.name == "Settings Button")
        {
            Debug.Log("Setings - Exit");
        }
        if (other.name == "Settings Button") enter = false;        
    }
}
