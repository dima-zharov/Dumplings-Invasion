using UnityEngine;

public abstract class FollowPlayer : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected DeathPlayer _player;
    protected Rigidbody _rigidbody;

    protected void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _player = FindObjectOfType<DeathPlayer>();
    }

    protected void CheckPlayerExistence()
    {
        if (_player.IsAlive)
            Follow();
        else
            _rigidbody.velocity = Vector3.zero;
    }

    protected abstract void Follow();

}
