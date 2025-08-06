using System;
using UnityEngine;
using Zenject;

public class LocationSaveLoader : IDataSaveLoader
{
    private LocationSystem _locationSystem;
    
    [Inject]
    public LocationSaveLoader(LocationSystem locationSystem)
    {
        _locationSystem = locationSystem;
        Debug.Log(_locationSystem);
    }
    
    public void SaveData()
    {
        Location location = _locationSystem.CurrentLocation;
        
        var data = new LocationDataSerializable { CurrentLocation = location, LocationID = location.LocationID, 
            MinimumUpgradePrice = location.MinimumUpgradePrice, MinimumLevel = location.MinimumLevel, MaxUpgradeLevel = location.MaxUpgradeLevel};
        
        Repository.SetData(data);
    }

    public void LoadData()
    {
        if (Repository.TryGetData(out LocationDataSerializable data) && data.CurrentLocation != null)
        {
            data.CurrentLocation.Init(data.LocationID, data.MinimumLevel, data.MinimumUpgradePrice, data.MaxUpgradeLevel);
            _locationSystem.Init(data.CurrentLocation);
        }
        else
        {
            _locationSystem.Init(_locationSystem.Locations[0]);
        }
    }
}

[Serializable]
public struct LocationDataSerializable
{
    public Location CurrentLocation;
    public int LocationID;
    public int MinimumUpgradePrice;
    public int MinimumLevel;
    public int MaxUpgradeLevel;
}
