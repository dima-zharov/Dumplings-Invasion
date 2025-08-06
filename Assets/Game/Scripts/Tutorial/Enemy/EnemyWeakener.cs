using UnityEngine;

public class EnemyWeakener : MonoBehaviour
{
    [SerializeField] private float _weakValue;
    private PushPlayer _enemyPush;
    public void WeakEnemy(GameObject enemy)
    {
        if (enemy.TryGetComponent<PushPlayer>(out _enemyPush))
        {
            _enemyPush.SetStartForce( - _weakValue);
        }
    }
}
