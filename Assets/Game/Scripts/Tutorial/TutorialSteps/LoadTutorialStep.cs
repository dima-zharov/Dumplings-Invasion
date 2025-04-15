using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadTutorialStep : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialUI;
    [SerializeField] private TutorialDeathPlayer _deathPlayer;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private TutorialPlayerJumpToStartPosition _playerJumpToStartPosition;
    [SerializeField] private TutorialEnemySpawn _enemySpawner;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TutorialStep[] _steps;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private TextMeshProUGUI _instructionText;
    [SerializeField] private GameObject _startButton;
    
    private GameObject _enemy;

    private int _currentStepIndex = 0;
    private int _failCount = 0;
    
    public bool IsEnemySpawn { get; set; }
    
    public GameObject EnemyObject => _enemy;

    private void Start()
    {
        StartStep();
        
        EnableUIElements();
    }

    private void StartStep()
    {
        CleanupPreviousEnemy();
        
        var step = _steps[_currentStepIndex];
        _instructionText.text = step.InstructionText;
        _videoPlayer.clip = step.VideoClip;
        _videoPlayer.Play();
        
        _failCount = 0;
    }

    public void SpawnEnemy()
    {
        _enemy = _enemySpawner.EnemySpawn(_steps[_currentStepIndex].EnemyPrefab);
        IsEnemySpawn = true;
    }

    private void RestartGame()
    {
        Invoke(nameof(EnableUIElements), 2f);
        _playerJumpToStartPosition.RestartPosition();
        IsEnemySpawn = false;
        CleanupPreviousEnemy();
        _deathPlayer.RevivePlayer();
        
    }

    private void EnableUIElements()
    {
        _tutorialUI.SetActive(true);
        _startButton.SetActive(true);
    }

    public void PlayerWin()
    {
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
    }

    public void PlayerLose()
    {
        RestartGame();
        _failCount++;
        if (_failCount == 2)
        {
            Debug.Log("Показать гифку-подсказку и текст помощи");
        }
        if (_failCount == 5)
        {
            Debug.Log("Враг ослаблен");
            
        }
    }

    private void FinishTutorial()
    {
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        _winPanel.SetActive(true);
        _playerRigidbody.isKinematic = true;
    }

    private void CleanupPreviousEnemy()
    {
        if (_enemy != null) Destroy(_enemy);
    }
}
