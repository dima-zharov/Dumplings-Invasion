using System;
using UnityEngine;
using Zenject;

public class MoneySaveLoader : IDataSaveLoader
{
    private MoneyData _moneyData;
    
    [Inject]
    public MoneySaveLoader(MoneyData moneyData)
    {
        _moneyData = moneyData;
        Debug.Log(_moneyData);
    }
    
    public void SaveData()
    {
        float money = _moneyData.CurrentMoney;
        float multiplier = _moneyData.Multiplier;
        
        var data = new MoneyDataSerializable { Money = money, Multiplier = multiplier };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        MoneyDataSerializable data = Repository.GetData<MoneyDataSerializable>();
        _moneyData.Init(data.Money, data.Multiplier);
    }
}

[Serializable]
public struct MoneyDataSerializable
{
    public float Money;
    public float Multiplier;
}
