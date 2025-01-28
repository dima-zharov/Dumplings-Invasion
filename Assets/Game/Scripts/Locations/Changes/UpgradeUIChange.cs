using System;
using UnityEngine;

public class UpgradeUIChange : MonoBehaviour
{
    [SerializeField] private LocationSystem _locationSystem;

    public event Action OnUpgradedUI;

    private void OnEnable() { _locationSystem.OnChangedLocation += Change; }
    private void OnDisable() { _locationSystem.OnChangedLocation -= Change; }

    private void Change(Location location)
    {
        OnUpgradedUI?.Invoke();
    }
}
