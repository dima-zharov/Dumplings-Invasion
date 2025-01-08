using UnityEngine;

public class PotatoBehaviour : FollowPlayer
{
    [SerializeField]private float _radius;
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
        Vector3 direction = (_player.transform.position - transform.position).normalized;

        Vector3 midPoint = _player.transform.position - direction * _radius;

        if(transform.position.x > _radius)
            transform.position = new Vector3(_radius, 0, 0);
        else if(transform.position.z > _radius)
            transform.position = new Vector3(0, 0, _radius);

        Vector3 targetPosition = (midPoint - transform.position).normalized * _speed;
        _rigidbody.AddForce(targetPosition);
    }

}
