using UnityEngine;
using Zenject;
using System.Collections.Generic;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class DataSaveLoader : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeginning;
    [SerializeField] private LoadLevel _loadLevel;

    private List<IDataSaveLoader> _dataSaveLoaders;

    [Inject]
    public void Construct(List<IDataSaveLoader> dataSaveLoaders)
    {
        _dataSaveLoaders = dataSaveLoaders;
    }

    private void OnEnable()
    {
        _gameBeginning.OnGameStarted += LoadData;
        _loadLevel.OnLevelLoaded += SaveData;
    }

    private void OnDisable()
    {
        _gameBeginning.OnGameStarted -= LoadData;
        _loadLevel.OnLevelLoaded -= SaveData;
    }

    [ContextMenu("DeleteAllData")]
    private void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveData()
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

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }

}