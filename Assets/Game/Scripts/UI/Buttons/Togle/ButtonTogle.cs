using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonTogle : MonoBehaviour
{
    public bool IsActive;

    public void TogleState(Action firstAction, Action secondAction)
    {
        if (IsActive)
            secondAction();
        else
            firstAction();

        IsActive = !IsActive;
    }
}
