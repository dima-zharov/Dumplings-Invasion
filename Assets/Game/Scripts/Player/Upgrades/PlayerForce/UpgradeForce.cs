using UnityEngine;

public class UpgradeForce : Upgrade
{
    [SerializeField] private LocationSystem _locationSystem;
    [SerializeField] private PlayerChange _playerChange;
    [SerializeField] private UpgradeUI _upgradeUI;

    private PlayerForce _playerForce;

    private float _increaseForce = 0.1f;

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

        _upgradeLevel = 0;
        _upgradeUI.ChangeUpgradeText();
    }

    private void ChangePlayer(Player player)
    {
        _playerForce = player.GetComponent<PlayerForce>();
    }

    protected override void UpgradeAbility()
    {
        _playerForce.UpgradeForce(_increaseForce);
    }
}
