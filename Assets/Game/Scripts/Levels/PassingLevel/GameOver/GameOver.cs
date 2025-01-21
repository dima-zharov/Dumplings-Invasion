using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public event Action OnGameOver;
    public void FinishGame()
    {
        OnGameOver?.Invoke();
    }
}
