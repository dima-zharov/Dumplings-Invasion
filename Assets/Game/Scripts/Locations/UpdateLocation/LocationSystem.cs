using System;
using UnityEngine;

public class LocationSystem : MonoBehaviour
{
    [SerializeField] private Location[] _locations;
    [SerializeField] private Levels _levels;
    [SerializeField] private NextLevel _nextLevel; 
    public int CurrentLocationId {get; private set;}
    
    public Location[] Locations => _locations;
    public event Action<Location> OnChangedLocation;


    private void Awake()
    {
        CheckTransitionToNewLocation();
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
            }
        }
    }
}
