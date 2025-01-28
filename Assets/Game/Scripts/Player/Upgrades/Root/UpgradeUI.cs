using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradePriceText;
    [SerializeField] private TextMeshProUGUI _upgradeLevelText;
    [SerializeField] private Upgrade _upgrade;
    [SerializeField] private UpgradeBuyAnimation _upgradeBuyAnimation;

    private void Start()
    {
        ChangeUpgradeText();
    }

    public void ChangeUpgradeText()
    {
        _upgradePriceText.text = _upgrade.GetUpgradePrice().ToString();
        _upgradeLevelText.text = _upgrade.GetUpgradeLevel().ToString();
    }
    public void ChangeUpgardeBuyAnimation(Image image)
    {
        _upgradeBuyAnimation.ChooseUpgradeAnimation(_upgrade.IsUpgradeAvaliable, image);
    }
}
