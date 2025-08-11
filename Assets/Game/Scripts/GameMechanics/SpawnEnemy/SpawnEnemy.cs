using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private EnemyCombination _enemyCombination;
    [SerializeField] private EnemyStartSettings _startSettings;
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private PlayerChange _playerChange;
    [SerializeField] private RestartLevel _restartLevel;

    private DeathPlayer _player;
    private Vector3 _spawnPosition;

    private List<Enemy> _enemiesCombination = new();
    private List<Enemy> _enemies = new();

    private float _spawnZMax = -3.5f;
    private float _spawnZMin = -9;
    private float _spawnXMax = 3;
    private float _spawnXMin = -3;
    private float _spawnY = 5.5f;
    private float _zoneRadius = 3;
    private bool _isSpawning;

    public event Action OnEnemiesDied;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += DestroyAllEnemy;
        _restartLevel.OnRestartedLevel += DestroyAllEnemy;
        _playerChange.OnChangedPlayer += ChangePlayer;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= DestroyAllEnemy;
        _restartLevel.OnRestartedLevel -= DestroyAllEnemy;
        _playerChange.OnChangedPlayer -= ChangePlayer;
    }

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

    private void ChangePlayer(Player player)
    {
        _player = player.GetComponent<DeathPlayer>();
    }

    public void Spawn()
    {
        _enemiesCombination = _enemyCombination.GetEnemyCombination().ToList();

        for (int i = 0; i < _enemiesCombination.Count; i++)
        {
            Enemy enemy = Instantiate(_enemiesCombination[i], GenerateSpawnPosition(), Quaternion.identity);

            _enemies.Add(enemy);
            _startSettings.SetSettings(enemy);

        }

        _isSpawning = true;
    }

    public void SpawnBoss()
    {
        _enemies.Add(Instantiate(_enemyCombination.GetBoss(), GenerateSpawnPosition(), Quaternion.identity));

        _isSpawning = true;
    }

    private Vector3 GenerateSpawnPosition()
    {
        do
        {
            float spawnX = UnityEngine.Random.Range(_spawnXMin, _spawnXMax);
            float spawnZ = UnityEngine.Random.Range(_spawnZMin, _spawnZMax);

            _spawnPosition = new Vector3(spawnX, _spawnY, spawnZ);
        }
        while (Vector3.Distance(_spawnPosition, _player.transform.position) < _zoneRadius);

        return _spawnPosition;
    }

    public void DestroyAllEnemy()
    {
        if (_enemies.Count > 0)
        {
            foreach (var enemy in _enemies)
            {
                if(enemy != null)
                    Destroy(enemy.gameObject);
            }

            _enemies.Clear();
        }
    }
}
