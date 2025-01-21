using UnityEngine;

public class UpgradeMultiplier : Upgrade
{
    [SerializeField] private MoneyData _moneyData;

    private float _increaseMultiplier = 0.2f;

    private void Awake()
    {
        _startUpgradePrice = 10;
        _upgradePrice = _startUpgradePrice;
    }

    protected override void UpgradeAbility()
    {
        _moneyData.UpgradeMultiplier(_increaseMultiplier);
    }
}
