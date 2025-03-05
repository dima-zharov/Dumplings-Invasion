using System.Collections.Generic;
using UnityEngine;

public class ChangePlatformsState : MonoBehaviour
{
    [SerializeField] private LocationSystem _locations;
    [SerializeField] private List<PlatformData> _platforms;
    [SerializeField] private NextLevel _nextLevel;
    [SerializeField] private Levels _levels;


    private void Start()
    {
        SetPlatformsTile();
    }

    private void OnEnable()
    {
        _nextLevel.OnCompleteLevel += SetPlatformsTile;
    }

    private void OnDisable()
    {
        _nextLevel.OnCompleteLevel -= SetPlatformsTile;
    }

    public void SetPlatformsTile()
    {

        for (int i = 0; i < _platforms.Count; i++)
        {
            if(_levels.CurrentLevel > 1)
                _platforms[i].ChangeLocalId();

            _platforms[i].AddLevelToId(_levels.CurrentLevel, i);

            if (_platforms[i].PlatformLevel <= _locations.Locations[0].MinimumLevel)
                ActivatePlatfomTile(0, i);
            else if(_platforms[i].PlatformLevel >= _locations.Locations[1].MinimumLevel && _platforms[i].PlatformLevel < _locations.Locations[2].MinimumLevel)
                ActivatePlatfomTile(1, i);
            else if(_platforms[i].PlatformLevel >= _locations.Locations[2].MinimumLevel)
                ActivatePlatfomTile(2, i);

        }
    }

    private void ActivatePlatfomTile(int tileNumber, int platformNumber)
    {
        if (tileNumber == 0)
        {
            _platforms[platformNumber].SetTileToPlatform(0, true);
            _platforms[platformNumber].SetTileToPlatform(1, false);
            _platforms[platformNumber].SetTileToPlatform(2, false);
        }
        else if (tileNumber == 1)
        {
            _platforms[platformNumber].SetTileToPlatform(0, false);
            _platforms[platformNumber].SetTileToPlatform(1, true);
            _platforms[platformNumber].SetTileToPlatform(2, false);
        }
        else if (tileNumber == 2)
        { 
            _platforms[platformNumber].SetTileToPlatform(0, false);
            _platforms[platformNumber].SetTileToPlatform(1, false);
            _platforms[platformNumber].SetTileToPlatform(2, true);
        }
    }

}
