using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private UpgradeBuyAnimation _upgradeBuyAnimation;
    [SerializeField] private Image _upgradeIcon;
    
    protected float _upgradePrice;
    protected float _startUpgradePrice;
    protected int _upgradeLevel;

    public static event Action<float> OnUpgradedAbility;

    public bool IsUpgradeAvaliable { get; private set; }
    public int UpgradeLevel => _upgradeLevel;
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
            _soundPlayer.PlayPurchaseSound();
            UpgradeAbility();
            OnUpgradedAbility?.Invoke(_upgradePrice);

            _upgradeLevel++;
            RaisePrice();
            _upgradeBuyAnimation.EnableUpgradeAnimtion(_upgradeIcon);
        }
        else
        {
            _soundPlayer.PlayNotEnoughtMoneySound();
            _upgradeBuyAnimation.DisableUpgradeAnimtion(_upgradeIcon);
        }
    }

    public float GetUpgradePrice() => _upgradePrice;
    public int GetUpgradeLevel() => _upgradeLevel;
}

