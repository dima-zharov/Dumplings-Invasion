using System;
using UnityEngine;

public class ExplosiveAttack : MonoBehaviour
{
    [SerializeField] private float _explosiveForce;
    [SerializeField] private float _explosionRadius;
    
    public event Action OnPotatoExploded;

    private void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddExplosionForce(_explosiveForce, transform.position, _explosionRadius);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Explode();
            OnPotatoExploded?.Invoke();
        }
    }
}
