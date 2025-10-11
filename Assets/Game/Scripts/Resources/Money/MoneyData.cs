using System;
using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class MoneyData : MonoBehaviour
{
    [SerializeField] private NextLevel _nextLevel;

    private float _currentMoney;
    private float _multiplier;
    private float _increaseMoney;

    public float CurrentMoney => _currentMoney;
    public float Multiplier => _multiplier;

    public event Action OnMoneyChange;

    private void Start()
    {
        _increaseMoney = 10;
        
        if (!PlayerPrefs.HasKey("firstOpen"))
            _multiplier = 1;
    }

    private void OnEnable()
    {
        _nextLevel.OnCompleteLevel += AddMoney;
        Upgrade.OnUpgradedAbility += RemoveMoney;
    }

    private void OnDisable()
    {
        _nextLevel.OnCompleteLevel -= AddMoney;
        Upgrade.OnUpgradedAbility -= RemoveMoney;
    }

    [ContextMenu(nameof(AddMoney))]
    private void AddMoney()
    {
        _currentMoney += (int)Math.Round(_multiplier * _increaseMoney);

        OnMoneyChange?.Invoke();
    }

    public void Init(float money, float multiplier)
    {
        _currentMoney = money;
        _multiplier = multiplier;
        
        OnMoneyChange?.Invoke();
    }

    private void RemoveMoney(float amount)
    {
        if (_currentMoney < amount)
            _currentMoney = 0;
        else
            _currentMoney -= amount;

        OnMoneyChange?.Invoke();
    }

    public void UpgradeMultiplier(float increase)
    {
        _multiplier += increase;
    }
}
