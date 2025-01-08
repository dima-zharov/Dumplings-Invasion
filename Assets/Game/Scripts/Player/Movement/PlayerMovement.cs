using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private const string ACTION_NAME = "Movement";

    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private MovementHandler _movementHandler;
    private PlayerPosition _position;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _position = GetComponent<PlayerPosition>();
        _rigidbody = GetComponent<Rigidbody>();
        _moveAction = _playerInput.actions.FindAction(ACTION_NAME);
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


}
