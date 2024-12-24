using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnRange;
    [SerializeField] private RestartLevel _restartLevel;

    private List<Enemy> _enemies = new();
    private bool _isSpawning;

    public event Action OnEnemiesDied;

    private void OnEnable()
    {
        _restartLevel.OnRestartedLevel += DestroyAllEnemy;
    }

    private void OnDisable()
    {
        _restartLevel.OnRestartedLevel -= DestroyAllEnemy;
    }

    private void Update()
    {
        if (_isSpawning && _enemies.Count == 0)
        {
            OnEnemiesDied?.Invoke();
            _isSpawning = false;
        }

        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == null)
                _enemies.Remove(_enemies[i]);
        }
    }

    public void Spawn(int enemiesToSpawn, Enemy spawnObject, Quaternion rotation)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            _enemies.Add(Instantiate(spawnObject, GenerateSpawnPosition(), rotation));
        }
        _isSpawning = true;
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = UnityEngine.Random.Range(-_spawnRange.x, _spawnRange.x);
        float spawnZ = UnityEngine.Random.Range(-_spawnRange.z, _spawnRange.z);

        return new Vector3(spawnX, _spawnRange.y, spawnZ);
    }

    public void DestroyAllEnemy()
    {
        if (_enemies.Count > 0)
        {
            foreach (var enemy in _enemies)
            {
                _enemies.Remove(enemy);
            }
        }
    }
}
