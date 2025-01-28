using UnityEngine;

public class UpgradeAbility : MonoBehaviour
{
    [SerializeField] private MoneyData _moneyData;
    [SerializeField] private UpgradeBuyAnimation _upgradeBuyAnimation;

    public void Upgrade(Upgrade ability)
    {
        ability.TryUpgrade(_moneyData);
    }
}
