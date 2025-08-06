using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    public int PlatformLevel { get; private set; }
    [SerializeField] private int _localId;
    [SerializeField] private GameObject[] _tilesPrefabs;

    public void AddLevelToId(int currentLevel)
    {
        PlatformLevel = _localId + currentLevel;
    }


    public void SetTileToPlatform(int numberOfTile)
    {
        for (int i = 0; i < _tilesPrefabs.Length; i++)
        {
            if (i == numberOfTile)
                _tilesPrefabs[i].SetActive(true);
            else
                _tilesPrefabs[i].SetActive(false);
        }
    }


}
