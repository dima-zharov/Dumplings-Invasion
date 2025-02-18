using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class BlockPlayerMovement : MonoBehaviour
{
    [SerializeField] private SpawnEnemy _enemySpawner;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private StartLevel _startLevel;

    private bool _isMoving;

    public bool IsMoving => _isMoving;

    private void OnEnable()
    {
        _gameOver.OnGameOver += BlockMovement;
        _enemySpawner.OnEnemiesDied += BlockMovement;
        _startLevel.OnStartedLevel += EnableMovement;
    } 
    private void OnDisable()
    {
        _gameOver.OnGameOver -= BlockMovement;
        _enemySpawner.OnEnemiesDied -= BlockMovement;
        _startLevel.OnStartedLevel -= EnableMovement;
    }

    public void BlockMovement() { _isMoving = false; }
    public void EnableMovement() { _isMoving = true; }
}