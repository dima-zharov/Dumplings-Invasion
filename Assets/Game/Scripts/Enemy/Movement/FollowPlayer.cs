using UnityEngine;

public abstract class FollowPlayer : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected DeathPlayer _player;
    protected Rigidbody _rigidbody;

    protected bool _isMovement = false;

    protected void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _player = FindObjectOfType<DeathPlayer>();
    }

    protected virtual void CheckPlayerExistence()
    {
        if (_player.IsAlive && _isMovement)
            Follow();
        else
            _rigidbody.velocity = Vector3.zero;
    }

    protected abstract void Follow();

    public void AllowMovement()
    {
        _isMovement = true;
    }

}
