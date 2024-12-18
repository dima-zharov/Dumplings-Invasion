using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private const string ACTION_NAME = "Movement";

    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _moveAction = _playerInput.actions.FindAction(ACTION_NAME);

    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = _moveAction.ReadValue<Vector2>();
        _rigidbody.velocity = new Vector3(direction.x, _rigidbody.velocity.y, direction.y) * _speed * Time.fixedDeltaTime;

    }
}
