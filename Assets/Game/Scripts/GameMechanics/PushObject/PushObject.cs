using System.Collections;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private Rigidbody _enemyRigidbody;
    private float _speed;

    protected void Push(GameObject enemy, GameObject player, float pushForce)
    {
        _playerRigidbody = player.GetComponent<Rigidbody>();
        _enemyRigidbody = enemy.GetComponent<Rigidbody>();

        _speed = _playerRigidbody.velocity.magnitude;

        Vector3 directionToEnemy = (enemy.transform.position - player.transform.position).normalized;
        directionToEnemy.y = 0;

        Vector3 pushDirection = directionToEnemy * pushForce * _speed;

        _enemyRigidbody.AddForce(pushDirection);
    }
}
