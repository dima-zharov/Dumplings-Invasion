using UnityEngine;

public class UpgradeForce : Upgrade
{
    [SerializeField] private PlayerForce _playerForce;

    private float _increaseForce = 0.1f;

    private void Awake()
    {
        _startUpgradePrice = 10;
        _upgradePrice = _startUpgradePrice;
    }

    protected override void UpgradeAbility()
    {
        _playerForce.UpgradeForce(_increaseForce);
    }
}
