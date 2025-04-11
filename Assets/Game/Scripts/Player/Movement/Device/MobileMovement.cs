using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MobileMovement : IMovement
{
    private Joystick _joystick;

    [Inject]
    public MobileMovement(Joystick joystick)
    {
        _joystick = joystick;
    }
    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Vector2 direction = _joystick.Direction * speed;
        rigidbody.AddForce(direction.x, 0, direction.y);
    }
}
