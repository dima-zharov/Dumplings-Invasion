using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCarrotMovement : TutorialFollowPlayer
{
    [SerializeField] private float _duration;
    [SerializeField] private float _timeOfTrack;

    private float _elapsedTime;
    private float _shotDelay = 0.2f;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        CheckPlayerExistence();
    }

    protected override void CheckPlayerExistence()
    {
        if (_player.IsAlive && _isMovement)
        {
            StartCoroutine(StartAttack());
            _isMovement = false;
        }
        else if (!_player.IsAlive)
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    protected override void Follow()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);

        _isMovement = true;
    }

    private void RotateToPlayer()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _duration);
    }

    private IEnumerator StartAttack()
    {
        _elapsedTime = 0;

        while (_elapsedTime < _timeOfTrack)
        {
            yield return new WaitForSeconds(0.01f);
            _elapsedTime += 0.01f;

            RotateToPlayer();
        }

        yield return new WaitForSeconds(_shotDelay);
        Follow();
    }
}
