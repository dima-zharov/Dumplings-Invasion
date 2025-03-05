using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    public int PlatformLevel { get; private set; }
    [SerializeField] private GameObject[] _tilesPrefabs;
    private List<int> _allIds = new List<int>() { 0, 1, 2};

    public void AddLevelToId(int currentLevel, int platformNumber)
    {
        PlatformLevel = _allIds[platformNumber] + currentLevel;
    }

    public void SetTileToPlatform(int numberOfTile, bool isActive)
    {
        _tilesPrefabs[numberOfTile].SetActive(isActive);
    }

    public void ChangeLocalId()
    {
        int firstId = _allIds[0];
        int secondId = _allIds[1];
        int thirdId = _allIds[2];
        _allIds[0] = secondId;
        _allIds[1] = thirdId;
        _allIds[2] = firstId;
    }

}
