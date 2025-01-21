using TMPro;
using UnityEngine;

public class MoneyDataUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentMoneyText;
    [SerializeField] private MoneyData _moneyData;

    private void Start()
    {
        ChangeMoneyText();
    }

    private void OnEnable() => _moneyData.OnMoneyChange += ChangeMoneyText;
    private void OnDisable() => _moneyData.OnMoneyChange -= ChangeMoneyText;

    private void ChangeMoneyText()
    {
        _currentMoneyText.text = _moneyData.CurrentMoney.ToString();
    }
}
