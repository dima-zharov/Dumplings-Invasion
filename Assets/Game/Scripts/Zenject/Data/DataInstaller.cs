using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    private const string PLAYER_ID_KEY = "PlayerId";
    private int _currnetPlayerId;
    
    [SerializeField] private PlayersScroller _playersScroller;
    [SerializeField] private MoneyData _moneyData;
    [SerializeField] private List<PlayerForce> _playerForce;
    [SerializeField] private List<DefenceAbility> _defenceAbility;
    [SerializeField] private UpgradeForce _upgradeForce;
    [SerializeField] private UpgradeDefence _upgradeDefence;
    [SerializeField] private UpgradeMultiplier _upgradeMultiplier;
    [SerializeField] private LocationSystem _locationSystem;

    public override void InstallBindings()
    {
        _currnetPlayerId = PlayerPrefs.GetInt(PLAYER_ID_KEY);

        Container.Bind<PlayersScroller>().FromInstance(_playersScroller).AsSingle();
        Container.Bind<IUnlocker>().To<WatchAddUnlockPlayer>().AsSingle();
        Container.Bind<IUnlocker>().To<BuyPlayerUnlock>().AsSingle();

        Container.Bind<LocationSystem>().FromInstance(_locationSystem).AsSingle();
        Container.Bind<IDataSaveLoader>().To<LocationSaveLoader>().AsSingle();

        Container.Bind<MoneyData>().FromInstance(_moneyData).AsSingle();
        Container.Bind<IDataSaveLoader>().To<MoneySaveLoader>().AsSingle();

        Container.Bind<UpgradeMultiplier>().FromInstance(_upgradeMultiplier).AsSingle();
        Container.Bind<IDataSaveLoader>().To<MultiplierSaveLoader>().AsSingle();

        Container.Bind<PlayerForce>().FromInstance(_playerForce[_currnetPlayerId]).AsSingle();
        Container.Bind<UpgradeForce>().FromInstance(_upgradeForce).AsSingle();
        Container.Bind<IDataSaveLoader>().To<StrengthSaveLoader>().AsSingle();

        Container.Bind<DefenceAbility>().FromInstance(_defenceAbility[_currnetPlayerId]).AsSingle();
        Container.Bind<UpgradeDefence>().FromInstance(_upgradeDefence).AsSingle();
        Container.Bind<IDataSaveLoader>().To<DefenceSaveLoader>().AsSingle();

    }
}