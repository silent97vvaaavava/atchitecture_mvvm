using Assets.Training.Domain;
using Core.MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Training.MVVM.Model;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int Coins = 100;
    public int Crystals = 50;

    public List<Product> Products = new()
    {
        new Product("Item 1", 10, true),
        new Product("Item 2", 20, true),
        new Product("Item 3", 30, false)
    };

    public SettingsData SettingsData = new SettingsData { Sound = true, Music = true };
}

public class SaveModel : IModel
{
    private const string SaveFilePath = "saveData.json";

    public SaveModel() { }

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
