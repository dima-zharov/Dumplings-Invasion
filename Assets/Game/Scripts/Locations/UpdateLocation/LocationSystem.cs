using System;
using UnityEngine;

public class LocationSystem : MonoBehaviour
{
    [field:SerializeField] public Location[] Locations { get; private set; }
    [SerializeField] private Levels _levels;
    [SerializeField] private NextLevel _nextLevel; 

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
                OnChangedLocation?.Invoke(location);
        }
    }
}
