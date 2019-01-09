using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public int frameRate = 60;
    public static string[] controllers;
    public static bool loading;

    void Start()
    {
        controllers = new string[2];
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = 0;

        /*if (!Application.isEditor) Cursor.visible = false;
        else                       Cursor.visible = true;*/

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < 2; x++)
        {
            if (names.Length > x && names[x].Length == 19) controllers[x] = "PS4";
            else                                           controllers[x] = "XBOX";
        }
        Image saveIcon = GameObject.Find("Auto Save Icon").GetComponent<Image>();
        saveIcon.CrossFadeAlpha(0, 0, false);
    }
}