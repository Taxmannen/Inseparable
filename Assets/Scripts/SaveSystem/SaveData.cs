using System;

[Serializable]
public class SaveData
{
    public string[] settingsStr;
    public float[] settingsFloat;
    public int[] settingsInt;

    public SaveData(GameSettings gs)
    { 
        settingsStr = new string[1];
        settingsFloat = new float[0];
        settingsInt = new int[0];

        settingsStr[0] = gs.level;
    }
}
