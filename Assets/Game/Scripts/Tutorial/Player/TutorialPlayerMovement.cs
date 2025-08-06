using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialPlayerMovement : MonoBehaviour
{
    private const string ACTION_NAME = "Movement";

    [SerializeField] private float _startPlayerSpeed;
    [SerializeField] private MovementHandlerInit _movementHandlerInit;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private MovementHandler _movementHandler;
    private TutorialPlayerBlockMovement _blockPlayerMovement;

    private float _speed;
    private bool _isGrounded;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _blockPlayerMovement = GetComponent<TutorialPlayerBlockMovement>();

        _moveAction = _playerInput.actions[ACTION_NAME];

        _movementHandler = _movementHandlerInit.Handler;
        _speed = _startPlayerSpeed;
    }

    private void FixedUpdate()
    {
        if (_isGrounded && _movementHandler != null && _blockPlayerMovement.IsMoving)
        {
            _movementHandler.Movement.Move(_moveAction, _speed, _rigidbody);
        }
    }

    public bool IsPlayerMoving() => _moveAction.ReadValue<Vector2>() != Vector2.zero;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pan"))
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pan"))
            _isGrounded = false;
    }
}
