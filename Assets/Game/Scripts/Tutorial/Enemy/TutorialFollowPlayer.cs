using UnityEngine;

public abstract class TutorialFollowPlayer : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected TutorialDeathPlayer _player;
    protected Rigidbody _rigidbody;

    protected bool _isMovement = false;

    protected void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _player = FindObjectOfType<TutorialDeathPlayer>();
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
