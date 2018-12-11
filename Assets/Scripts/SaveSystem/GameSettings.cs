using UnityEngine;
using UnityEngine.SceneManagement;

/* Script made by Daniel */
public class GameSettings : MonoBehaviour {
    public string level;

    public void Save()
    {
        level = SceneManager.GetActiveScene().name;

        SaveSystem.Save(this);
    }

    public void Load()
    {
        string[] settingsStr  = SaveSystem.Load().settingsStr;
        float[] settingsFloat = SaveSystem.Load().settingsFloat;
        int[] settingsInt     = SaveSystem.Load().settingsInt;

        level = settingsStr[0];

        LevelManager levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();
        levelManager.Load(level);
    }
}
