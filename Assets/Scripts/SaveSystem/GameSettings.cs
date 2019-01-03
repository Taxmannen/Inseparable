using UnityEngine;
using UnityEngine.SceneManagement;

/* Script made by Daniel */
public class GameSettings : MonoBehaviour {
    public string level;
    public float player1PosX;
    public float player1PosY;

    public bool[] levers;
    public static GameSettings gameSettings;

    private void Start()
    {
        if (gameSettings == null) gameSettings = this;    
    }
    public void Save(Vector2 loadPosition)
    {
        level = SceneManager.GetActiveScene().name;
        player1PosX = loadPosition.x;
        player1PosY = loadPosition.y;
        SaveSystem.Save(this);
    }

    public void LoadOnContinue()
    {
        string[] settingsStr  = SaveSystem.Load().settingsStr;
        float[] settingsFloat = SaveSystem.Load().settingsFloat;
        bool[] levers = SaveSystem.Load().levers;

        level = settingsStr[0];

        player1PosX = settingsFloat[0];
        player1PosY = settingsFloat[1];

        this.levers = levers;
        LevelManager levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();
        levelManager.Load(level);
    }
}