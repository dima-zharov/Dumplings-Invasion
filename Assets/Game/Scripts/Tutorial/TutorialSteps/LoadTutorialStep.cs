using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LoadTutorialStep : MonoBehaviour
{
    [SerializeField] private EnemyWeakener _enemyWeakener;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private AppearanceStartAnimation _tutorialUI;
    [SerializeField] private TutorialDeathPlayer _deathPlayer;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private TutorialPlayerJumpToStartPosition _playerJumpToStartPosition;
    [SerializeField] private TutorialEnemySpawn _enemySpawner;
    [SerializeField] private SlideAnimation _winPanel;
    [SerializeField] private TutorialStep[] _steps;
    [SerializeField] private VideoPlayerManager _videoPlayerManager;
    [SerializeField] private TextMeshProUGUI _instructionText;
    [SerializeField] private ButtonIntaracteble _startButton;

    private GameObject _enemy;

    private int _currentStepIndex = 0;
    private int _failCount = 0;

    public bool IsEnemySpawn { get; set; }
    public bool IsTutorialStepActive { get; private set; } = false;

    public GameObject EnemyObject => _enemy;

    private void Start()
    {
        StartStep();
        EnableUIElements();
    }

    private void StartStep()
    {
        CleanupPreviousEnemy();
        _deathPlayer.RevivePlayer();
        var step = _steps[_currentStepIndex];
        _instructionText.text = step.InstructionText;
        _videoPlayerManager.ChoseVideoClip(_currentStepIndex);
        _failCount = 0;
    }

    public void SpawnEnemy()
    {
        _enemy = _enemySpawner.EnemySpawn(_steps[_currentStepIndex].EnemyPrefab);
        IsEnemySpawn = true;
        IsTutorialStepActive = true;
    }

    private void RestartGame()
    {
        Invoke(nameof(EnableUIElements), 1f);
        _playerJumpToStartPosition.RestartPosition();
        IsEnemySpawn = false;
        CleanupPreviousEnemy();
        _deathPlayer.RevivePlayer();

    }

    private void EnableUIElements()
    {
        _tutorialUI.gameObject.SetActive(true);
        _tutorialUI.StartAnimation();
        _startButton.EnableButton();
    }

    public void PlayerWin()
    {
        if(_currentStepIndex != 2)
            _winSound.Play();
        IsEnemySpawn = false;
        _currentStepIndex++;
        if (_currentStepIndex < _steps.Length)
        {
            StartStep();
            RestartGame();
        }
        else
        {
            FinishTutorial();
        }
        IsTutorialStepActive = false;
    }

    public void PlayerLose()
    {
        IsTutorialStepActive = false;
        _loseSound.Play();
        RestartGame();
        _failCount++;
        if (_failCount >= 2)
        {
            _instructionText.text = _steps[_currentStepIndex].HelpText;
        }
        if (_failCount == 5)
        {
            _enemyWeakener.WeakEnemy(_steps[_currentStepIndex].EnemyPrefab);
        }
    }

    private void FinishTutorial()
    {
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        _winPanel.GetComponent<AudioSource>().Play();
        _winPanel.StartAnimation();
        _playerRigidbody.isKinematic = true;
    }

    private void CleanupPreviousEnemy()
    {
        if (_enemy != null) Destroy(_enemy);
    }
}
