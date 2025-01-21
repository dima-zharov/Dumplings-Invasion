using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradePriceText;
    [SerializeField] private TextMeshProUGUI _upgradeLevelText;
    [SerializeField] private Upgrade _upgrade;

    private void Start()
    {
        ChangeUpgradeText();
    }

    public void ChangeUpgradeText()
    {
        _upgradePriceText.text = _upgrade.GetUpgradePrice().ToString();
        _upgradeLevelText.text = _upgrade.GetUpgradeLevel().ToString();
    }
}
