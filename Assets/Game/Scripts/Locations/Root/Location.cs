using UnityEngine;

[CreateAssetMenu(fileName = "NewLocation", menuName = "Game/Location")]
public class Location : ScriptableObject
{
    [SerializeField] private int _locationId;
    [SerializeField] private int _minimumLevel;
    [SerializeField] private int _minimumUpgradePrice;
    [SerializeField] private int _maxUpgradeLevel;
    

    public int MinimumLevel => _minimumLevel;
    public int MinimumUpgradePrice => _minimumUpgradePrice;
    public int LocationID => _locationId;
    public int MaxUpgradeLevel => _maxUpgradeLevel;

    public void Init(int locationId, int minimumLevel, int minimumUpgradePrice, int maxUpgradeLevel)
    {
        _locationId = locationId;
        _minimumLevel = minimumLevel;
        _minimumUpgradePrice = minimumUpgradePrice;
        _maxUpgradeLevel = maxUpgradeLevel;
    }
}
