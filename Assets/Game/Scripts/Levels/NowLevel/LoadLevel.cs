using System;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public event Action OnLevelLoaded;

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        OnLevelLoaded?.Invoke();
    }
}
