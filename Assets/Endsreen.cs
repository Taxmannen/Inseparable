using UnityEngine;

public class Endsreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Menu Player 1 XBOX")) 
        {
            Application.Quit();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
