using UnityEngine;

public class UpgradeDefence : Upgrade
{
    [SerializeField] private LocationSystem _locationSystem;
    [SerializeField] private PlayerChange _playerChange;
    [SerializeField] UpgradeUI _upgradeUI;

    private DefenceAbility _defenceAbility;

    private float _increaseDefence = 0.1f;

    private void OnEnable()
    {
        _locationSystem.OnChangedLocation += Init;
        _playerChange.OnChangedPlayer += ChangePlayer;
    }
    private void OnDisable()
    {
        _locationSystem.OnChangedLocation -= Init;
        _playerChange.OnChangedPlayer -= ChangePlayer;
    }

    private void Init(Location location)
    {
        _startUpgradePrice = location.MinimumUpgradePrice;
        _upgradePrice = _startUpgradePrice;
        _upgradeUI.ChangeUpgradeText();
    }

    private void ChangePlayer(Player player)
    {
        _defenceAbility = player.GetComponent<DefenceAbility>();
    }

    protected override void UpgradeAbility()
    {
        _defenceAbility.SetDefence(_increaseDefence);
    }

    public void LoadData(int upgradeLevel, float upgradePrice)
    {
        _upgradeLevel = upgradeLevel;
        _upgradePrice = upgradePrice;
        
        _upgradeUI.ChangeUpgradeText();
    }
}
