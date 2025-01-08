using UnityEngine;

public class SpawnWave : MonoBehaviour
{

    private SpawnEnemy _spawnEnemy;

    private void Awake()
    {
        _spawnEnemy = GetComponent<SpawnEnemy>();
    }


    public void Spawn()
    {
        _spawnEnemy.Spawn();
    }
}
