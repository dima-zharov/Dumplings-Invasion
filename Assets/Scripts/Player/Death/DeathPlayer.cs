using System;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public event Action OnPlayerDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
            OnPlayerDead?.Invoke();
    }
}
