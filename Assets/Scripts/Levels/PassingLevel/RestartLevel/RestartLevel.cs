using System;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public event Action OnRestartedLevel;

    public void Restart()
    {
        OnRestartedLevel?.Invoke();
    }
}
