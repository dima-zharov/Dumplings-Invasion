using UnityEngine;

public class PushEnemy : PushObject
{
    [SerializeField] private PlayerForce _playerForce;
    [SerializeField] private PlayerSplash _playerSplash;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _playerMovement.IsPlayerMoving())
        {
            Push(enemy.gameObject, gameObject, _playerForce.PushForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float hitForce = collision.relativeVelocity.magnitude;
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _playerMovement.IsPlayerMoving())
        {
            if (hitForce >= _playerSplash.MinPushForce)
                _playerSplash.MakeParticles(collision.transform.position);
        }

    }
}
