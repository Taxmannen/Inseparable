using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public int frameRate = 60;
    public static string[] controllers;
    public static bool loading;

    void Start()
    {
        controllers = new string[2];
        controllers[0] = "XBOX";
        controllers[1] = "XBOX";
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = 0;

        if (!Application.isEditor) Cursor.visible = false;
        else                       Cursor.visible = true;

        Image saveIcon = GameObject.Find("Auto Save Icon").GetComponent<Image>();
        saveIcon.CrossFadeAlpha(0, 0, false);
    }
}