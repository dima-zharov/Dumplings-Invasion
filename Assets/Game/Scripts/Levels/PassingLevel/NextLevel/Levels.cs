using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private LevelUI _levelUI;
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private NextLevel _nextLevel;

    private int _currentLevel = 1;

    public int CurrentLevel => _currentLevel;

    private void OnEnable()
    {
        _restartLevel.OnRestartedLevel += RestartLevel;
        _nextLevel.OnCompleteLevel += Next;
    }
    private void OnDisable()
    {
        _restartLevel.OnRestartedLevel -= RestartLevel;
        _nextLevel.OnCompleteLevel -= Next;
    }

    public void Next()
    {
        _currentLevel++;
        _levelUI.ChangeLevel();
    }

    public void RestartLevel()
    {
        _currentLevel = 1;
        _levelUI.ChangeLevel();
    }

}
