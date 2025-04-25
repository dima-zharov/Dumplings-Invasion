using System;
using UnityEngine;

public class GameCompletion : MonoBehaviour
{
    public bool IsEndlessModeEnable { get; private set; }
    public event Action OnGameCompleted;
    private int _lastLevelToFinishGame = 30;
    

    public void TryCompleteGame(int currentLevel)
    {
        if (currentLevel - 1 == _lastLevelToFinishGame && !IsEndlessModeEnable)
        {
            OnGameCompleted?.Invoke();
            IsEndlessModeEnable = true;
        }
        else if (currentLevel - 1 > _lastLevelToFinishGame)
            IsEndlessModeEnable = true;
    }

    [ContextMenu(nameof(CompleteGame))]
    private void CompleteGame()
    {
        OnGameCompleted.Invoke();
    }
}
