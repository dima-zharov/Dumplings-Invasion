using System;
using UnityEngine;

public class GameCompletion : MonoBehaviour
{
    private const string ENDLESS_MODE_STATE_KEY = "EndlessMode";
    public bool IsEndlessModeEnable { get; private set; }
    public event Action OnGameCompleted;
    public event Action OnLoadCompletedGame;
    private int _lastLevelToFinishGame = 30;
    

    public void TryCompleteGame(int currentLevel)
    {
        LoadEndlessModeState();
        if (currentLevel - 1 == _lastLevelToFinishGame && !IsEndlessModeEnable)
        {
            OnGameCompleted?.Invoke();
            PlayerPrefs.SetInt(ENDLESS_MODE_STATE_KEY, 1);
        }

        else if (currentLevel > _lastLevelToFinishGame)
            OnLoadCompletedGame?.Invoke();
    }

    private void LoadEndlessModeState()
    {
        if (PlayerPrefs.GetInt(ENDLESS_MODE_STATE_KEY) == 1)
            IsEndlessModeEnable = true;
        else
            IsEndlessModeEnable = false;
    }

    [ContextMenu(nameof(CompleteGame))]
    private void CompleteGame()
    {
        OnGameCompleted.Invoke();
    }
}
