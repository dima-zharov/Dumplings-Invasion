using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PushEnemy : PushObject
{
    [SerializeField] private PlayerForce _playerForce;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _playerMovement.IsPlayerMoving())
            Push(enemy.gameObject, gameObject, _playerForce.PushForce);
    }
}
