using System;
using System.Linq;
using UnityEngine;
using YG;

public class LocationSystem : MonoBehaviour
{
    [SerializeField] private Location[] _locations;
    [SerializeField] private Levels _levels;
    [SerializeField] private NextLevel _nextLevel; 
    [SerializeField] private ChangePlatformsState _changePlatformsState;
    
    private Location _currentLocation;
    
    public int CurrentLocationId {get; private set;}
    public Location CurrentLocation => _currentLocation;
    
    public Location[] Locations => _locations;
    public event Action<Location> OnChangedLocation;
    public event Action OnChangedLocationGlobal;

    public void Init(Location currentLocation)
    {
        PlayerUnlockState.InitializeDefaultUnlocked(_locations.Length);

        CurrentLocationId = currentLocation.LocationID;
        _currentLocation = currentLocation;
        
        OnChangedLocation?.Invoke(currentLocation);
        _changePlatformsState.SetPlatformsTile();

    }

    private void OnEnable() => _nextLevel.OnCompleteLevel += CheckTransitionToNewLocation;
    private void OnDisable() => _nextLevel.OnCompleteLevel -= CheckTransitionToNewLocation;

    private void CheckTransitionToNewLocation()
    {
        foreach (var location in Locations)
        {
            if (_levels.CurrentLevel == location.MinimumLevel)
            {
                OnChangedLocation?.Invoke(location);
                CurrentLocationId = location.LocationID;
                _currentLocation = location;
                OnChangedLocationGlobal?.Invoke();
            }
        }
    }
}
