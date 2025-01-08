using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private EnemyCombination _enemyCombination;
    [SerializeField] private DeathPlayer _player;

    private List<Enemy> _enemiesCombination = new();
    private List<Enemy> _enemies = new();

    private float _spawnZMax = -3.5f;
    private float _spawnZMin = -9;
    private float _spawnXMax = 3;
    private float _spawnXMin = -3;
    private float _spawnY = 5.5f;
    private bool _isSpawning;

    public event Action OnEnemiesDied;

    private void Update()
    {
        if (_isSpawning && _enemies.Count == 0 && _player.IsAlive)
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

    public void Spawn()
    {
        _enemiesCombination = _enemyCombination.GetEnemyCombination().ToList();

        for (int i = 0; i < _enemiesCombination.Count; i++)
        {
            _enemies.Add(Instantiate(_enemiesCombination[i], GenerateSpawnPosition(), Quaternion.identity));
        }

        _isSpawning = true;
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = UnityEngine.Random.Range(_spawnXMin, _spawnXMax);
        float spawnZ = UnityEngine.Random.Range(_spawnZMin, _spawnZMax);

        return new Vector3(spawnX, _spawnY, spawnZ);
    }

    public void DestroyAllEnemy()
    {
        if (_enemies.Count > 0)
        {
            foreach (var enemy in _enemies)
            {
                Destroy(enemy.gameObject);
            }

            _enemies.Clear();
        }
    }
}
