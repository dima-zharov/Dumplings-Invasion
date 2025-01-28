using UnityEngine;

public class DefenceAbility : MonoBehaviour
{
    [SerializeField] private float _currentDefence;

    public float CurrentDefence => _currentDefence;

    public void SetDefence(float defence)
    {
        _currentDefence += defence;
    }
}
