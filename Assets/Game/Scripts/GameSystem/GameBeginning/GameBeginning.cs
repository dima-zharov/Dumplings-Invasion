using System;
using UnityEngine;

public class GameBeginning : MonoBehaviour
{
    public event Action OnGameFirstOpen;
    public event Action OnGameStarted;

    private void Start()
    {
        if(PlayerPrefs.GetInt("firstOpen") == 0)
            OnGameFirstOpen?.Invoke();
        OnGameStarted?.Invoke();
    }
}
