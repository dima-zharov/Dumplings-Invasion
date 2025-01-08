using System;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private SpawnEnemy _spawnEnemy;

    public void Restart()
    {
        _spawnEnemy.DestroyAllEnemy();
        _loadLevel.Load();
    }
}
