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
        settingsFloat = new float[2];
        settingsInt = new int[0];

        settingsStr[0] = gs.level;

        settingsFloat[0] = gs.player1PosX;
        settingsFloat[1] = gs.player1PosY;
    }
}
