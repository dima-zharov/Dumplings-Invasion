using System;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public event Action OnStartedLevel;

    public void Begin()
    {
        OnStartedLevel?.Invoke();
    }
}
