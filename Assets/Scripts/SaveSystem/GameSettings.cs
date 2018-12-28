using UnityEngine;
using UnityEngine.SceneManagement;

/* Script made by Daniel */
public class GameSettings : MonoBehaviour {
    public string level;
    public float player1PosX;
    public float player1PosY;

    public bool growingBridge;

    public void Save(Vector2 loadPosition)
    {
        level = SceneManager.GetActiveScene().name;
        player1PosX = loadPosition.x;
        player1PosY = loadPosition.y;
        SaveSystem.Save(this);
    }

    public void Load()
    {
        string[] settingsStr  = SaveSystem.Load().settingsStr;
        float[] settingsFloat = SaveSystem.Load().settingsFloat;
        bool[] setingsBool    = SaveSystem.Load().settingsBool;

        level = settingsStr[0];

        player1PosX = settingsFloat[0];
        player1PosY = settingsFloat[1];

        growingBridge = setingsBool[0];

        LevelManager levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();
        levelManager.Load(level);
    }
}