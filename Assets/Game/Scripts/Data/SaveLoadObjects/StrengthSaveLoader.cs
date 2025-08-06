using System;
using UnityEngine;
using Zenject;

public class StrengthSaveLoader : IDataSaveLoader
{
    private UpgradeForce _upgradeForce;
    private PlayerForce _playerForce;
    
    [Inject]
    public StrengthSaveLoader(UpgradeForce upgradeForce, PlayerForce playerForce)
    {
        _upgradeForce = upgradeForce;
        _playerForce = playerForce;
    }
    
    public void SaveData()
    {
        int upgradeLevel = _upgradeForce.GetUpgradeLevel();
        float upgradePrice = _upgradeForce.GetUpgradePrice();
        float pushForce = _playerForce.PushForce;
        
        var data = new StrengthDataSerializable { UpgradeLevel = upgradeLevel, UpgradePrice = upgradePrice, PushForce = pushForce };
        Repository.SetData(data);
    }

    public void LoadData()
    {
        if (Repository.TryGetData(out StrengthDataSerializable data))
        {
            _upgradeForce.LoadData(data.UpgradeLevel, data.UpgradePrice);
            _playerForce.Init(data.PushForce);
        }
    }
}

[Serializable]
public struct StrengthDataSerializable
{
    public int UpgradeLevel;
    public float UpgradePrice;
    public float PushForce;
}
