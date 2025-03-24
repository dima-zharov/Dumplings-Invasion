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


    public void SetTileToPlatform(int numberOfTile, bool isActive)
    {
        _tilesPrefabs[numberOfTile].SetActive(isActive);
    }


}
