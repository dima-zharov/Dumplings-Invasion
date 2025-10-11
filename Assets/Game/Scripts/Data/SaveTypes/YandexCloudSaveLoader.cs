using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using YG;
using YG.Insides;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class YandexCloudSaveLoader : ISaveType
{
    public void LoadData()
    {
        YGInsides.LoadProgress();
    }

    public void SaveData()
    {
      
        PlayerPrefs.Save();
    }

    public void SetData<T>(T value)
    {
        var serializedData = JsonConvert.SerializeObject(value);
        PlayerPrefs.SetString(value.GetType().Name, serializedData);
    }

    public bool TryGetData<T>(out T value)
    {
        string typeName = typeof(T).Name;
        if (PlayerPrefs.HasKey(typeName)) 
        { 
            value = JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(typeName));
            return true;
        }

        value = default;
        return false;
    }
}
