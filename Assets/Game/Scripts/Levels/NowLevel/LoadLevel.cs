using System;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private bool _isLevelLoading;

    public bool IsLevelLoading => _isLevelLoading;

    public event Action OnLevelLoaded;

    public void Load()
    {
        _isLevelLoading = true;
        OnLevelLoaded?.Invoke();
    }

    public void DisableIsLevelLoading()
    {
        _isLevelLoading = false;
    }
}
