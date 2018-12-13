using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public int frameRate = 60;
    public bool cursor = true;
    public static string[] controllers;

    bool testButtons = false;

    void Start()
    {
        controllers = new string[2];
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = 0;
        Cursor.visible = cursor;

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < 2; x++)
        {
            if (names.Length > x && names[x].Length == 19) controllers[x] = "PS4";
            else                                           controllers[x] = "XBOX";
        }
        Image saveIcon = GameObject.Find("Auto Save Icon").GetComponent<Image>();
        saveIcon.CrossFadeAlpha(0, 0, false);
    }

    private void Update()
    {
        if (testButtons)
        {
            string player1 = "Player 1" + " " + controllers[0];
            string player2 = "Player 2" + " " + controllers[1];

            if (Input.GetButtonDown("Seperate" + " " + player1)) Debug.Log("Player 1 Seperate");
            if (Input.GetButtonDown("Seperate" + " " + player2)) Debug.Log("Player 2 Seperate");

            if (Input.GetButtonDown("Attack" + " " + player1)) Debug.Log("Player 1 Attack");
            if (Input.GetButtonDown("Attack" + " " + player2)) Debug.Log("Player 2 Attack");
        }  
    }
}