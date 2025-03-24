using System.Collections.Generic;
using UnityEngine;

public class ChangePlatformsState : MonoBehaviour
{
    [SerializeField] private LocationSystem _locations;
    [SerializeField] private List<PlatformData> _platforms;
    [SerializeField] private LevelTransition _levelTransition;
    [SerializeField] private Levels _levels;


    private void Start()
    {
        SetPlatformsTile();
    }

    private void OnEnable()
    {
        _levelTransition.OnCompleteTransition += SetPlatformsTile;
    }

    private void OnDisable()
    {
        _levelTransition.OnCompleteTransition -= SetPlatformsTile;
    }

    public void SetPlatformsTile()
    {
        for (int i = 0; i < _platforms.Count; i++)
        {
            _platforms[i].AddLevelToId(_levels.CurrentLevel);

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
        for (int i = 0; i < _platforms.Count; i++)
        {
            if(tileNumber == i)
                _platforms[platformNumber].SetTileToPlatform(i, true);
            else
                _platforms[platformNumber].SetTileToPlatform(i, false);
        }
    }

}
