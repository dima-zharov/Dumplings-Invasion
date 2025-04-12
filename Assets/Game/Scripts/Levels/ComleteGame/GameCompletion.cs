using System;
using UnityEngine;

public class GameCompletion : MonoBehaviour
{
    public bool IsEndlessModeEnable { get; private set; }
    public event Action OnGameCompleted;
    private int _lastLevelToFinishGame = 30;
    

    public void TryCompleteGame(int currentLevel)
    {
        if(currentLevel - 1 == _lastLevelToFinishGame)
        {
            OnGameCompleted?.Invoke();
            IsEndlessModeEnable = true;
        }
    }

    [ContextMenu(nameof(CompleteGame))]
    private void CompleteGame()
    {
        OnGameCompleted.Invoke();
    }
}
