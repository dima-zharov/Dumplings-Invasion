using UnityEngine;
using Zenject.Asteroids;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerPosition _player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _player = FindObjectOfType<PlayerPosition>();
    }

    private void FixedUpdate()
    {
        if (_player != null && _player.IsAlive)
            Follow();
        else
            _rigidbody.velocity = Vector3.zero;
    }

    private void Follow()
    {
        Vector3 target = new Vector3(_player.transform.position.x - transform.position.x, 0, _player.transform.position.z - transform.position.z).normalized * _speed;

        _rigidbody.AddForce(target);
    }
}
