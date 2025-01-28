using UnityEngine;

public class ContinueGameAttempts : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _secondChancePanel;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private int _numberOfAttempts;

    private int _currentAttempts;

    private void Awake()
    {
        _currentAttempts = _numberOfAttempts;
    }

    private void OnEnable() => _gameOver.OnGameOver += CheckAttempts;
    private void OnDisable() => _gameOver.OnGameOver -= CheckAttempts;

    private void CheckAttempts()
    {
        if (_currentAttempts == 0)
        {
            _losePanel.SetActive(true);
            _currentAttempts = _numberOfAttempts;
        }
        else
        {
            _secondChancePanel.SetActive(true);
        }
    }

    public void SpendAttemp() => _currentAttempts--;
}
