using UnityEngine;

public class PushObject : MonoBehaviour
{
    [field:SerializeField] public bool NeedSpeedToPush { get; private set; }
    private Rigidbody _playerRigidbody;
    private Rigidbody _enemyRigidbody;
    private DefenceAbility _defenceAbility;

    private float _speed;
    private float _force;

    protected void Push(GameObject enemy, GameObject player, float pushForce)
    {
        _playerRigidbody = player.GetComponent<Rigidbody>();
        _enemyRigidbody = enemy.GetComponent<Rigidbody>();
        
        CalculatePushForce(enemy, pushForce);

        _speed = _playerRigidbody.velocity.magnitude;

        Vector3 directionToEnemy = (enemy.transform.position - player.transform.position).normalized;
        directionToEnemy.y = 0;

        Vector3 pushDirection = directionToEnemy * _force;
        if(NeedSpeedToPush)
            pushDirection = pushDirection * _speed;

        _enemyRigidbody.AddForce(pushDirection, ForceMode.Impulse);
    }

    private void CalculatePushForce(GameObject enemy, float pushForce)
    {
        _defenceAbility = enemy.GetComponent<DefenceAbility>();

        if (_defenceAbility != null)
            _force = pushForce - _defenceAbility.CurrentDefence;
        else
            _force = pushForce;

        if (_force < 0)
            _force = 0;
    }
}
