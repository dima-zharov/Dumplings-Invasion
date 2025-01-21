using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private const string ACTION_NAME = "Movement";

    [SerializeField] private float _startPlayerSpeed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private MovementHandler _movementHandler;
    private float _speed;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _moveAction = _playerInput.actions.FindAction(ACTION_NAME);

        _speed = _startPlayerSpeed;
    }
    private void FixedUpdate()
    {
        _movementHandler.Movement.Move(_moveAction, _speed, _rigidbody);
    }

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
    }

    public bool IsPlayerMoving() => _moveAction.ReadValue<Vector2>() != Vector2.zero;

    public void UpgradeSpeed(float increaseSpeed)
    {
        _speed += _startPlayerSpeed * increaseSpeed;
    }
}
