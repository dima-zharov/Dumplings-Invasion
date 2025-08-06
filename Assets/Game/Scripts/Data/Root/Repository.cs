using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Repository : MonoBehaviour
{
    private const string GAME_STATE_KEY = "GameState";

    private static Dictionary<string, string> _currentState = new();

    public static void LoadState()
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

    public static void SaveState()
    {
        var serializedState = JsonConvert.SerializeObject(_currentState);
        PlayerPrefs.SetString(GAME_STATE_KEY, serializedState);
    }

    public static T GetData<T>()
    {
        var serializedData = _currentState[typeof(T).Name];
        return JsonConvert.DeserializeObject<T>(serializedData);
    }

    public static void SetData<T>(T value)
    {
        var serializedData = JsonConvert.SerializeObject(value);
        _currentState[typeof(T).Name] = serializedData;
    }

    public static bool TryGetData<T>(out T value)
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
