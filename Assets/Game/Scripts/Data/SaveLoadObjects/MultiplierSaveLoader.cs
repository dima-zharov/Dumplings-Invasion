using System;
using UnityEngine;
using Zenject;

public class MultiplierSaveLoader : IDataSaveLoader
{
    private UpgradeMultiplier _upgradeMultiplier;
    
    [Inject]
    public MultiplierSaveLoader(UpgradeMultiplier upgradeMultiplier)
    {
        _upgradeMultiplier = upgradeMultiplier;
    }
    
    public void SaveData()
    {
        int upgradeLevel = _upgradeMultiplier.GetUpgradeLevel();
        float upgradePrice = _upgradeMultiplier.GetUpgradePrice();
        
        var data = new MultiplierDataSerializable { UpgradePrice = upgradePrice, UpgradeLevel = upgradeLevel };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        if (Repository.TryGetData(out MultiplierDataSerializable data))
            _upgradeMultiplier.Init(data.UpgradeLevel, data.UpgradePrice);
    }
}

[Serializable]
public struct MultiplierDataSerializable
{
    public float UpgradePrice;
    public int UpgradeLevel;
}
