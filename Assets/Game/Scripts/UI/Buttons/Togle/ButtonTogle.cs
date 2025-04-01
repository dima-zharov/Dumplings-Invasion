using System;
using UnityEngine;

public class ButtonTogle : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    public void TogleState(Action firstAction, Action secondAction)
    {
        if (_isActive)
            firstAction();
        else
            secondAction();

        _isActive = !_isActive;
    }
}
