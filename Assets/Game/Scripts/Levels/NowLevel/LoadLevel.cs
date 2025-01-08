using System;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public event Action OnLevelLoaded;

    public void Load()
    {
        OnLevelLoaded?.Invoke();
    }
}
