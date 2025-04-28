using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> OnPlayerInitialized;

    private void OnEnable()
    {

        OnPlayerInitialized?.Invoke(this);
    }
}
