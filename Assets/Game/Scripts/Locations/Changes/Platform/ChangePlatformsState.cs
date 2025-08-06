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
                _platforms[i].SetTileToPlatform(0);
            else if (_platforms[i].PlatformLevel >= _locations.Locations[1].MinimumLevel && _platforms[i].PlatformLevel < _locations.Locations[2].MinimumLevel)
                _platforms[i].SetTileToPlatform(1);
            else if (_platforms[i].PlatformLevel >= _locations.Locations[2].MinimumLevel)
                _platforms[i].SetTileToPlatform(2);

        }
    }

}
