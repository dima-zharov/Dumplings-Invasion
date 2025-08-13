using System;
using UnityEngine;

public class DefenceAbility : MonoBehaviour
{
    [SerializeField] private float _startDefence;
    
    private float _currentDefence;

    public float CurrentDefence => _currentDefence;

    private void Awake()
    {
        if (_currentDefence < _startDefence)
        {
            _currentDefence = _startDefence;
            Debug.Log(_currentDefence);
        }
    }

    public void Init(float currentDefence)
    {
        _currentDefence = currentDefence;
    }
    
    public void SetDefence(float defence)
    {
        _currentDefence += defence;
    }
}
