using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MobileMovement : IMovement
{
    private Joystick _joystick;
    public Vector2 LastInput { get; private set; }

    [Inject]
    public MobileMovement(Joystick joystick)
    {
        _joystick = joystick;
    }
    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Vector2 direction = _joystick.Direction * speed;
        LastInput = direction;
        rigidbody.AddForce(direction.x, 0, direction.y);
    }

}
