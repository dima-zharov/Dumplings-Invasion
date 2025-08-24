using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexCloudSaveLoader : JsonSaveLoader
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    public new void LoadData()
    {
        LoadExtern();
    }

    public new void SaveData()
    {
        base.SaveData();
        SaveExtern(PlayerPrefs.GetString(GAME_STATE_KEY));
    }



}
