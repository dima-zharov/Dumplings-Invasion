using System;
using UnityEngine;

public class GameBeginning : MonoBehaviour
{
    public event Action OnGameFirstOpen;
    public event Action OnGameStarted;

    private void Awake()
    {
        //if (PlayerPrefs.HasKey("firstOpen"))
        OnGameStarted?.Invoke();
    }

    public void StartGame()
    {
        OnGameFirstOpen?.Invoke();
    }
}
