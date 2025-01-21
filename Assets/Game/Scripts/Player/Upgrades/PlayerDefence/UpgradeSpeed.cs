using UnityEngine;

public class UpgradeSpeed : Upgrade
{
    [SerializeField] private PlayerMovement _playerMovement;

    private float _increaseSpeed = 0.1f;

    private void Awake()
    {
        _startUpgradePrice = 10;
        _upgradePrice = _startUpgradePrice;
    }

    protected override void UpgradeAbility()
    {
        _playerMovement.UpgradeSpeed(_increaseSpeed);
    }
}
