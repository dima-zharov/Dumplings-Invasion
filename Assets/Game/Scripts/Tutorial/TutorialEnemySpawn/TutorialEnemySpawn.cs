using UnityEngine;

public class TutorialEnemySpawn : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;

    
    public GameObject EnemySpawn(GameObject enemy)
    {
        Debug.Log(enemy.gameObject.transform.localScale);
        return Instantiate(enemy, _spawnPosition, Quaternion.identity);
    }
}
