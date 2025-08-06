using UnityEngine;
using DG.Tweening;

public class TutorialPlayerJumpToStartPosition : MonoBehaviour
{
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

    public void RestartPosition()
    {
        _rigidbody.isKinematic = true;
        
        transform.DOJump(_startPosition, _jumpForce, _jumpNumber, _jumpSpeed);
        transform.DORotate(_startRotation, _jumpSpeed).OnComplete(() => _rigidbody.isKinematic = false);
    }
}
