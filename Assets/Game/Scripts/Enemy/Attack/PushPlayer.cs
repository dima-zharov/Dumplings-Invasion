using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : PushObject
{
    [SerializeField] private float _pushForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            Push(player.gameObject, gameObject, _pushForce);
    }
}
