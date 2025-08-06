using UnityEngine;

public class ContinueGameAttempts : MonoBehaviour
{
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private SpawnEnemy _enemyDestroyer;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _secondChancePanel;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private int _numberOfAttempts;
    private AppearanceStartAnimation _losePanelAppearance;
    private AppearanceStartAnimation _secondChancePanelAppearance;

    private int _currentAttempts;

    private void OnEnable()
    {
        _gameOver.OnGameOver += () => _loseSound.Play();
    }

    private void OnDisable()
    {
        _gameOver.OnGameOver -= () => _loseSound.Play();
    }

    private void Awake()
    {
        _currentAttempts = _numberOfAttempts;
        _losePanelAppearance = _losePanel.GetComponent<AppearanceStartAnimation>();
        _secondChancePanelAppearance = _secondChancePanel.GetComponent<AppearanceStartAnimation>();
    }

    public void CheckAttempts()
    {
        if (_currentAttempts == 0)
        {
            _losePanel.gameObject.SetActive(true);
            _losePanelAppearance.StartAnimation();
            _currentAttempts = _numberOfAttempts;
            _gameOver.FinishGame();
        }
        else
        {
            _enemyDestroyer.DestroyAllEnemy();
            _secondChancePanel.gameObject.SetActive(true);
            _secondChancePanelAppearance.StartAnimation();
            
        }
    }

    public void SpendAttemp() => _currentAttempts--;
}
