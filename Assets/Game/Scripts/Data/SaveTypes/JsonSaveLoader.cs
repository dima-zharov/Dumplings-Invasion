using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class JsonSaveLoader : ISaveType
{
    protected const string GAME_STATE_KEY = "GameState";

    protected static Dictionary<string, string> _currentState = new();
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(GAME_STATE_KEY))
        {
            var serializedState = PlayerPrefs.GetString(GAME_STATE_KEY);
            _currentState = JsonConvert.DeserializeObject<Dictionary<string, string>>(serializedState);
        }
        else
        {
            _currentState = new Dictionary<string, string>();
        }
    }

    public void SaveData()
    {
        var serializedState = JsonConvert.SerializeObject(_currentState);
        PlayerPrefs.SetString(GAME_STATE_KEY, serializedState);
    }

    public void SetData<T>(T value)
    {
        var serializedData = JsonConvert.SerializeObject(value);
        _currentState[typeof(T).Name] = serializedData;
    }

    public bool TryGetData<T>(out T value)
    {
        if (_currentState.TryGetValue(typeof(T).Name, out var serializedData))
        {
            value = JsonConvert.DeserializeObject<T>(serializedData);
            return true;
        }

        value = default;
        return false;
    }
}
