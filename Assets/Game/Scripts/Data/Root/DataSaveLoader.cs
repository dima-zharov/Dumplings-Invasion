using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class DataSaveLoader : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeginning;

    private List<IDataSaveLoader> _dataSaveLoaders;

    [Inject]
    public void Construct(List<IDataSaveLoader> dataSaveLoaders)
    {
        _dataSaveLoaders = dataSaveLoaders;
    }

    private void OnEnable()
    {
        _gameBeginning.OnGameStarted += LoadData;
    }

    private void OnDisable()
    {
        _gameBeginning.OnGameStarted -= LoadData;
    }

    [ContextMenu("DeleteAllData")]
    private void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("firstOpen", 1);
        
        foreach (var dataSaveLoader in _dataSaveLoaders)
        {
            dataSaveLoader.SaveData();
        }

        Repository.SaveState();
    }

    private void LoadData()
    {
        Repository.LoadState();

        foreach (var dataSaveLoader in _dataSaveLoaders)
        {
            dataSaveLoader.LoadData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
