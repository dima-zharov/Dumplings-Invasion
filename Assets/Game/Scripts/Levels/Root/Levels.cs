using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private GameCompletion _completeGame;
    [SerializeField] private BestScore _bestScore;
    [SerializeField] private LevelUI _levelUI;
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private NextLevel _nextLevel;
    [SerializeField] private LocationSystem _locationSystem;

    private int _minimumLevel;
    private int _currentLevel = 1;

    public int CurrentLevel => _currentLevel;
    public int MinimumLevel => _minimumLevel;

    private void OnEnable()
    {
        _restartLevel.OnRestartedLevel += RestartLevel;
        _nextLevel.OnCompleteLevel += Next;
        _locationSystem.OnChangedLocation += Init;
    }
    private void OnDisable()
    {
        _restartLevel.OnRestartedLevel -= RestartLevel;
        _nextLevel.OnCompleteLevel -= Next;
        _locationSystem.OnChangedLocation -= Init;
    }

    private void Init(Location location)
    {
        _minimumLevel = location.MinimumLevel;
        RestartLevel();
    }

    public void Next()
    {
        _currentLevel++;
        _completeGame.TryCompleteGame(_currentLevel);
        _levelUI.ChangeLevel();
        _bestScore.TryChangeHighLevel(_currentLevel);
    }

    public void RestartLevel()
    {
        _currentLevel = _minimumLevel;
        _levelUI.ChangeLevel();
    }

}
