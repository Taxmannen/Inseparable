using UnityEngine;

public class Main : MonoBehaviour {
    public int frameRate;
    public bool cursor;
    public static string[] controllers;

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
    }

    private void Update()
    {
        //if (Input.GetButtonDown("Menu XBOX")) Debug.Log("Menu XBOX");
        //if (Input.GetButtonDown("Menu PS4"))  Debug.Log("Menu PS4");
    }
}