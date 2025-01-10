using System;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public event Action GameOver;

    public void Restart()
    {
        GameOver?.Invoke();
    }
}
