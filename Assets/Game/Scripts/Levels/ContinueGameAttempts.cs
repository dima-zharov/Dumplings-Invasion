using UnityEngine;

public class ContinueGameAttempts : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _secondChancePanel;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private DeathPlayer _playerDeth;
    [SerializeField] private int _numberOfAttempts;
    private AppearanceStartAnimtion _losePanelAppearance;
    private AppearanceStartAnimtion _secondChancePanelAppearance;

    private int _currentAttempts;

    private void Awake()
    {
        _currentAttempts = _numberOfAttempts;
        _losePanelAppearance = _losePanel.GetComponent<AppearanceStartAnimtion>();
        _secondChancePanelAppearance = _secondChancePanel.GetComponent<AppearanceStartAnimtion>();
    }

    private void OnEnable()
    {
        _gameOver.OnGameOver += _playerDeth.Kill;
    }
    private void OnDisable()
    {
        _gameOver.OnGameOver -= _playerDeth.Kill;
    }

    public void CheckAttempts()
    {
        if (_currentAttempts == 0)
        {
            _losePanelAppearance.StartAnimation();
            _currentAttempts = _numberOfAttempts;
        }
        else
        {
            _secondChancePanelAppearance.StartAnimation();
            _gameOver.FinishGame();
            
        }
    }

    public void SpendAttemp() => _currentAttempts--;
}
