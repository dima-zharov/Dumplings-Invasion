using UnityEngine;

public class UpgradeAbility : MonoBehaviour
{
    [SerializeField] private MoneyData _moneyData;

    public void Upgrade(Upgrade ability)
    {
        ability.TryUpgrade(_moneyData);
    }
}
