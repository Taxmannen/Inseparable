using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	void Start ()
    {
        Application.targetFrameRate = 60;
	}

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) SceneManager.LoadScene("Main"); // For Debug!
    }
}
