using System;
using Zenject;

public class DefenceSaveLoader: IDataSaveLoader
{
    private UpgradeDefence _upgradeDefence;
    private DefenceAbility _defenceAbility;
    
    [Inject]
    public DefenceSaveLoader(UpgradeDefence upgradeDefence, DefenceAbility defenceAbility)
    {
        _upgradeDefence = upgradeDefence;
        _defenceAbility = defenceAbility;
    }
    
    public void SaveData()
    {
        int upgradeLevel = _upgradeDefence.GetUpgradeLevel();
        float upgradePrice = _upgradeDefence.GetUpgradePrice();
        float currentDefence = _defenceAbility.CurrentDefence;
        
        var data = new DefenceDataSerializable {UpgradeLevel = upgradeLevel, UpgradePrice = upgradePrice, CurrentDefence = currentDefence};
        Repository.SetData(data);
    }

    public void LoadData()
    {
        if (Repository.TryGetData(out DefenceDataSerializable data))
        {
            _upgradeDefence.LoadData(data.UpgradeLevel, data.UpgradePrice);
            _defenceAbility.Init(data.CurrentDefence);
        }
    }
}

[Serializable]
public struct DefenceDataSerializable
{
    public float UpgradePrice;
    public int UpgradeLevel;
    public float CurrentDefence;
}
