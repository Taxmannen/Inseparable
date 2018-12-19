using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/* Script made by Michael */
public static class SaveSystem {

    public static void Save(GameSettings gs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inseparable.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(gs);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/inseparable.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}