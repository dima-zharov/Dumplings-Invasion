using UnityEngine;

public class TutorialEnemySpawn : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;

    
    public GameObject EnemySpawn(GameObject enemy)
    {
        return Instantiate(enemy, _spawnPosition, Quaternion.identity);
    }
}
