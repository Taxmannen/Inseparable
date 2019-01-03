using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string[] settingsStr;
    public float[] settingsFloat;
    public bool[] levers;

    public SaveData(GameSettings gs)
    {
        settingsStr = new string[1];
        settingsStr[0] = gs.level;

        settingsFloat = new float[2];
        settingsFloat[0] = gs.player1PosX;
        settingsFloat[1] = gs.player1PosY;

        //Debug.Log(gs.levers[1]);
        levers = gs.levers;
    }
}
