using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonTogle : MonoBehaviour
{
    public bool IsActive;

    public void TogleState(Action firstAction, Action secondAction)
    {
        if (IsActive)
            firstAction();
        else
            secondAction();

        IsActive = !IsActive;
    }
}
