using System;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private SpawnEnemy _spawnEnemy;

    public event Action OnCompleteLevel;

    private void OnEnable() { _spawnEnemy.OnEnemiesDied += LoadNextLevel; }
    private void OnDisable() { _spawnEnemy.OnEnemiesDied -= LoadNextLevel; }

    [ContextMenu(nameof(LoadNextLevel))]
    public void LoadNextLevel()
    {
        OnCompleteLevel?.Invoke();
        _loadLevel.Load();
    }
}
