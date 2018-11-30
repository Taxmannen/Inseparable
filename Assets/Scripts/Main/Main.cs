using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetButton("Cancel")) SceneManager.LoadScene(SceneManager.GetActiveScene().name); // For Debug!
    }
}