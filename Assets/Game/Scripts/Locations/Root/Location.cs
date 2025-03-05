using UnityEngine;

[CreateAssetMenu(fileName = "NewLocation", menuName = "Game/Location")]
public class Location : ScriptableObject
{
    [SerializeField] private int _locationId;
    [SerializeField] private int _minimumLevel;
    [SerializeField] private int _minimumUpgradePrice;
    

    public int MinimumLevel => _minimumLevel;
    public int MinimumUpgradePrice => _minimumUpgradePrice;
    public int LocationID => _locationId;
}
