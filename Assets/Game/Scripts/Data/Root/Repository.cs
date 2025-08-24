using UnityEngine;

public class Repository : MonoBehaviour
{

    private static ISaveType _currentSaveType;

    private void Awake()
    {
        _currentSaveType = new YandexCloudSaveLoader();
    }


    public static void LoadState()
    {
        _currentSaveType.LoadData();
    }

    public static void SaveState()
    {
        _currentSaveType.SaveData();
    }

  

    public static void SetData<T>(T value)
    {
        _currentSaveType.SetData(value);
    }

    public static bool TryGetData<T>(out T value) => _currentSaveType.TryGetData(out value);
}