using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Quaternion[] _enemyRotation;
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private NextLevel _nextLevel;

    private SpawnEnemy _spawnEnemy;
    private int _currentLevel => _nextLevel.CurrentLevel;

    private void Awake()
    {
        _spawnEnemy = GetComponent<SpawnEnemy>();
    }

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += Spawn;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= Spawn;
    }

    private void Spawn()
    {
        int randomEnemy = Random.Range(0, _enemies.Length);
        _spawnEnemy.Spawn(_currentLevel, _enemies[randomEnemy], _enemyRotation[randomEnemy]);
    }
}
