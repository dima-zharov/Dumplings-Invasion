using DG.Tweening;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _startRotation;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private int _jumpNumber;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

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
        _rigidbody.isKinematic = true;
        
        transform.DOJump(_startPosition, _jumpForce, _jumpNumber, _jumpSpeed);
        transform.DORotate(_startRotation, _jumpSpeed).OnComplete(() => _rigidbody.isKinematic = false);
    }
}
