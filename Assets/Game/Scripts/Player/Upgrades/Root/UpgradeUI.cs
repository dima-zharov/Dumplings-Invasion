using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradePriceText;
    [SerializeField] private TextMeshProUGUI _upgradeLevelText;
    [SerializeField] private Upgrade _upgrade;
    [SerializeField] private UpgradeBuyAnimation _upgradeBuyAnimation;
    [SerializeField] private LocationSystem _locationSystem;
    private void OnEnable()
    {
        _locationSystem.OnChangedLocationUI += ChangeUpgradeText;
    }
    private void OnDisable()
    {
        _locationSystem.OnChangedLocationUI -= ChangeUpgradeText;
    }
    public void ChangeUpgradeText()
    {
        if (_upgrade.GetUpgradeLevel() >= _locationSystem.CurrentLocation.MaxUpgradeLevel)
            _upgradePriceText.text = "максимум";
        else
            _upgradePriceText.text = _upgrade.GetUpgradePrice().ToString();
        
        _upgradeLevelText.text = _upgrade.GetUpgradeLevel().ToString();
    }
    public void ChangeUpgardeBuyAnimation(Image image)
    {
        _upgradeBuyAnimation.ChooseUpgradeAnimation(_upgrade.IsUpgradeAvaliable, image);
    }
}
