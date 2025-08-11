using System;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    public event Action OnStartedLevel;
    public bool IsGameStarted { get; private set;  } = false;
    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += Finish;
    }
    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= Finish;
    }

    public void Begin()
    {
        OnStartedLevel?.Invoke();
        IsGameStarted = true;
    }

    private void Finish() => IsGameStarted = false;
}
