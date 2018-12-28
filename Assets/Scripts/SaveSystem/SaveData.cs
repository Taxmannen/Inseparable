using System;

[Serializable]
public class SaveData
{
    public string[] settingsStr;
    public float[] settingsFloat;
    public bool[] settingsBool;

    public SaveData(GameSettings gs)
    {
        settingsStr = new string[1];
        settingsStr[0] = gs.level;

        settingsFloat = new float[2];
        settingsFloat[0] = gs.player1PosX;
        settingsFloat[1] = gs.player1PosY;

        settingsBool = new bool[1];
        settingsBool[0] = gs.growingBridge;
    }
}
