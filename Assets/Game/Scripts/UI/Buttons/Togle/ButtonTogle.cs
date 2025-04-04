using System;
using UnityEngine;

public class ButtonTogle : MonoBehaviour
{
    private bool _isActive = false;
    public void TogleState(Action firstAction, Action secondAction)
    {
        if (_isActive)
            secondAction();
        else
            firstAction();

        _isActive = !_isActive;
    }
}
