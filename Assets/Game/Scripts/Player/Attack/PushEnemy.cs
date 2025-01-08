using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PushEnemy : PushObject
{
    [SerializeField] private float _pushForce;
    private PlayerMovement _playerMovement;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _playerMovement.IsPlayerMoving()) 
            Push(enemy.gameObject, gameObject, _pushForce);
    }
}
