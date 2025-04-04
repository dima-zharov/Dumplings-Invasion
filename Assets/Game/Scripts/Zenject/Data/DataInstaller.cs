using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    [SerializeField] private MoneyData _moneyData;
    [SerializeField] private PlayerForce _playerForce;
    [SerializeField] private UpgradeForce _upgradeForce;
    [SerializeField] private UpgradeDefence _upgradeDefence;
    [SerializeField] private DefenceAbility _defenceAbility;
    [SerializeField] private UpgradeMultiplier _upgradeMultiplier;
    [SerializeField] private LocationSystem _locationSystem;
    
    public override void InstallBindings()
    {
        Container.Bind<LocationSystem>().FromInstance(_locationSystem).AsSingle();
        Container.Bind<IDataSaveLoader>().To<LocationSaveLoader>().AsSingle();
        
        Container.Bind<MoneyData>().FromInstance(_moneyData).AsSingle();
        Container.Bind<IDataSaveLoader>().To<MoneySaveLoader>().AsSingle();
        
        Container.Bind<UpgradeMultiplier>().FromInstance(_upgradeMultiplier).AsSingle();
        Container.Bind<IDataSaveLoader>().To<MultiplierSaveLoader>().AsSingle();
        
        Container.Bind<PlayerForce>().FromInstance(_playerForce).AsSingle();
        Container.Bind<UpgradeForce>().FromInstance(_upgradeForce).AsSingle();
        Container.Bind<IDataSaveLoader>().To<StrengthSaveLoader>().AsSingle();
        
        Container.Bind<DefenceAbility>().FromInstance(_defenceAbility).AsSingle();
        Container.Bind<UpgradeDefence>().FromInstance(_upgradeDefence).AsSingle();
        Container.Bind<IDataSaveLoader>().To<DefenceSaveLoader>().AsSingle();
        
    }
}
