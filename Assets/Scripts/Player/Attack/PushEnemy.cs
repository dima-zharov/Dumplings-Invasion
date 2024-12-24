using UnityEngine;

public class PushEnemy : PushObject
{
    [SerializeField] private float _pushForce;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _rigidbody.velocity != Vector3.zero) 
            Push(enemy.gameObject, gameObject, _pushForce);
    }
}
