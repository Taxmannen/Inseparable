using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugRestart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Debug Restart")) SceneManager.LoadScene("Menu");
    }
}
