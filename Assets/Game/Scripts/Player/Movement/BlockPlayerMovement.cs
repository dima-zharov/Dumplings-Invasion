using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class BlockPlayerMovement : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private GameOver _gameOver;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += BlockMovement;
        _gameOver.OnGameOver += BlockMovement;
    } 
    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= BlockMovement;
        _gameOver.OnGameOver -= BlockMovement;
    }  

    public void BlockMovement() => GetComponent<PlayerMovement>().enabled = false;
    public void EnableMovement() => GetComponent<PlayerMovement>().enabled = true;
}
