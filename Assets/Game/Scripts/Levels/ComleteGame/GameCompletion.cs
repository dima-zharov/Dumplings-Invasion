using System;
using UnityEngine;

public class GameCompletion : MonoBehaviour
{
    public event Action OnGameCompleted;
    private int _lastLevelToFinishGame = 30;

    public void TryCompleteGame(int currentLevel)
    {
        if(currentLevel + 1 == _lastLevelToFinishGame)
            OnGameCompleted?.Invoke();
    }

    [ContextMenu(nameof(CompleteGame))]
    private void CompleteGame()
    {
        OnGameCompleted.Invoke();
    }
}
