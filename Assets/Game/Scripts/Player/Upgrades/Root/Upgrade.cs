using System;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    protected float _upgradePrice;
    protected float _startUpgradePrice;
    protected int _upgradeLevel;

    public static event Action<float> OnUpgradedAbility;

    protected abstract void UpgradeAbility();

    private void RaisePrice()
    {
        _upgradePrice += _startUpgradePrice / 10;
    }

    public virtual void TryUpgrade(MoneyData moneyData)
    {
        if (moneyData.CurrentMoney >= _upgradePrice)
        {
            UpgradeAbility();
            OnUpgradedAbility?.Invoke(_upgradePrice);

            _upgradeLevel++;
            RaisePrice();
        }
    }

    public float GetUpgradePrice() => _upgradePrice;
    public float GetUpgradeLevel() => _upgradeLevel;
}

