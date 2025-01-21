using DG.Tweening;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private int _jumpNumber;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += RestartPosition;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= RestartPosition;
    }


    private void RestartPosition()
    {
        transform.DOJump(_startPosition, _jumpForce, _jumpNumber, _jumpSpeed);
        transform.DORotate(new Vector3(-90, -90, 90), _jumpSpeed);
    }
}
