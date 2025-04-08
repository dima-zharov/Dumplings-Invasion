using UnityEngine;

public class TutorialBroccoliMovement : TutorialFollowPlayer
{
    private void Awake()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        CheckPlayerExistence();
    }

    protected override void Follow()
    {
        Vector3 target = new Vector3(_player.transform.position.x - transform.position.x, 0, _player.transform.position.z - transform.position.z).normalized * _speed;
        _rigidbody.AddForce(target);
    }
}
