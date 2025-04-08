using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPotatoMovement : TutorialFollowPlayer
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
       
        Vector3 targetPosition = (midPoint - transform.position).normalized * _speed;
        _rigidbody.AddForce(targetPosition);

        if(transform.position.x > _radius || transform.position.z > _radius || transform.position.x < _radius || transform.position.z < _radius)
            _rigidbody.AddForce(direction * _speed);
    }
}
