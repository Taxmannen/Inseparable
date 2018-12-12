using UnityEngine;
using UnityEngine.SceneManagement;

/* Script made by Daniel */
public class GameSettings : MonoBehaviour {
    public string level;
    public float player1PosX;
    public float player1PosY;

    public void Save()
    {
        level = SceneManager.GetActiveScene().name;
        player1PosX = GameObject.Find("Player 1").transform.position.x;
        player1PosY = GameObject.Find("Player 1").transform.position.y;

        SaveSystem.Save(this);
    }

    public void Load()
    {
        string[] settingsStr  = SaveSystem.Load().settingsStr;
        float[] settingsFloat = SaveSystem.Load().settingsFloat;
        //int[] settingsInt     = SaveSystem.Load().settingsInt;

        level = settingsStr[0];

        player1PosX = settingsFloat[0];
        player1PosY = settingsFloat[1];

        LevelManager levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();
        levelManager.Load(level);
    }
}