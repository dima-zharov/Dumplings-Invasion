using System.Collections.Generic;
using UnityEngine;
public class PlayerUnlockState
{
    private const string KEY_PREFIX = "PlayerUnlocked_";
    private static Dictionary<int, bool> _cachedUnlocks = new Dictionary<int, bool>();
    public static void InitializeDefaultUnlocked(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (!IsUnlocked(i))
                Unlock(i);
        }
    }
    public static bool IsUnlocked(int index)
    {
        if (_cachedUnlocks.TryGetValue(index, out bool cachedValue))
            return cachedValue;

        bool value = PlayerPrefs.GetInt(KEY_PREFIX + index, 0) == 1;
        _cachedUnlocks[index] = value;
        return value;
    }

    public static void Unlock(int index)
    {
        PlayerPrefs.SetInt(KEY_PREFIX + index, 1);
        PlayerPrefs.Save();
        _cachedUnlocks[index] = true;
    }
}