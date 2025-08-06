using UnityEngine;

public class UpgradeAbility : MonoBehaviour
{
    [SerializeField] private MoneyData _moneyData;
    [SerializeField] private LocationSystem _locationSystem;
    public void Upgrade(Upgrade ability)
    {
        if (ability.UpgradeLevel < _locationSystem.CurrentLocation.MaxUpgradeLevel)
            ability.TryUpgrade(_moneyData);
    }
}
