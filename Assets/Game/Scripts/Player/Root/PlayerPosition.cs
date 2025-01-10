using DG.Tweening;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private int _jumpNumber;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += RestartPosition;
        _restartLevel.GameOver += RestartPosition; 
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= RestartPosition;
        _restartLevel.GameOver -= RestartPosition;
    }


    private void RestartPosition()
    {
        transform.DOJump(_startPosition, _jumpForce, _jumpNumber, _jumpSpeed);
    }
}
