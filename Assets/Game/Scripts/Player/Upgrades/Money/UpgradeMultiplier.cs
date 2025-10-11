using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class UpgradeMultiplier : Upgrade
{
    [SerializeField] private MoneyData _moneyData;
    [SerializeField] private UpgradeUI _upgradeUI;

    private float _increaseMultiplier = 0.2f;

    private void Start()
    {
        _upgradeUI.ChangeUpgradeText();
    }
    private void Awake()
    {
        _startUpgradePrice = 10;
        
        if (!PlayerPrefs.HasKey("firstOpen"))
            _upgradePrice = _startUpgradePrice;
    }

    protected override void UpgradeAbility()
    {
        _moneyData.UpgradeMultiplier(_increaseMultiplier);
    }

    public void Init(int upgradeLevel, float upgradePrice)
    {
        _upgradePrice = upgradePrice;
        _upgradeLevel = upgradeLevel;
        
        
        _upgradeUI.ChangeUpgradeText();
    }
}
