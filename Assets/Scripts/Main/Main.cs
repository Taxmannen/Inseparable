using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public int frameRate = 60;
    public static bool loading;

    void Start()
    {
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = 0;

        if (!Application.isEditor) Cursor.visible = false;
        else                       Cursor.visible = true;

        Image saveIcon = GameObject.Find("Auto Save Icon").GetComponent<Image>();
        saveIcon.CrossFadeAlpha(0, 0, false);
    }
}