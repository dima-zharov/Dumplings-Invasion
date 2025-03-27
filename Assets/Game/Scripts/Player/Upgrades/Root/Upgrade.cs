using System;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    protected float _upgradePrice;
    protected float _startUpgradePrice;
    protected int _upgradeLevel;

    public static event Action<float> OnUpgradedAbility;

    public bool IsUpgradeAvaliable {  get; private set; }

    protected abstract void UpgradeAbility();

    private void RaisePrice()
    {
        _upgradePrice += _startUpgradePrice / 10;
    }

    public virtual void TryUpgrade(MoneyData moneyData)
    {
        IsUpgradeAvaliable = moneyData.CurrentMoney >= _upgradePrice;
        if (IsUpgradeAvaliable)
        {
            UpgradeAbility();
            OnUpgradedAbility?.Invoke(_upgradePrice);

            _upgradeLevel++;
            RaisePrice();
        }
    }

    public float GetUpgradePrice() => _upgradePrice;
    public int GetUpgradeLevel() => _upgradeLevel;
}

