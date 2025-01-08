using System;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    public event Action OnPlayerDead;

    public void RevivePlayer()
    {
        _isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            OnPlayerDead?.Invoke();
            _isAlive = false;
        }
    }
}
