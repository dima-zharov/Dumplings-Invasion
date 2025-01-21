using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    [SerializeField] private Levels _levels;

    private SpawnEnemy _spawnEnemy;

    private void Awake()
    {
        _spawnEnemy = GetComponent<SpawnEnemy>();
    }

    public void Spawn()
    {
        if(_levels.CurrentLevel % 2 == 0)
            _spawnEnemy.SpawnBoss();
        else
            _spawnEnemy.Spawn();
    }
}
