using System;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private bool _isLevelLoading;

    public bool IsLevelLoading => _isLevelLoading;

    public event Action OnLevelLoaded;

    public void Load()
    {
        OnLevelLoaded?.Invoke();
        _isLevelLoading = true;
    }

    public void DisableIsLevelLoading()
    {
        _isLevelLoading = false;
    }
}
