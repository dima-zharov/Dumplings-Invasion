using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (_player != null)
            Follow();
    }

    private void Follow()
    {
        Vector3 target = (_player.transform.position - transform.position) * _speed;

        _rigidbody.AddForce(target);
    }
}
