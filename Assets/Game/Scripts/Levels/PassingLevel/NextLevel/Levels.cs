using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private RestartLevel _restartLevel;

    private int _currentLevel = 1;

    public int CurrentLevel => _currentLevel;

    private void OnEnable()
    {
        _restartLevel.GameOver += RestartLevel;
    }

    private void OnDisable()
    {
        _restartLevel.GameOver -= RestartLevel;
    }

    public void Next()
    {
        _currentLevel++;
        _loadLevel.Load();
    }

    public void RestartLevel()
    {
        _currentLevel = 1;
    }

}
