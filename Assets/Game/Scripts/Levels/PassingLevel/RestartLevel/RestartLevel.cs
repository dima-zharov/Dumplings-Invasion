using System;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;

    public event Action OnRestartedLevel;

    public void Restart()
    {
        OnRestartedLevel?.Invoke();
        _loadLevel.Load();
    }
}
