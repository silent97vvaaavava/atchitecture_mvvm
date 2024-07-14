using Core.MVVM.Model;
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int Coins;
    public int Crystals;
}

public class SaveModel : IModel
{
    private const string SaveFilePath = "saveData.json";

    public SaveModel()
    {
    }

    public SaveData Load()
    {
        if (!File.Exists(SaveFilePath))
            return new SaveData();

        var json = File.ReadAllText(SaveFilePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SaveFilePath, json);
    }
}
