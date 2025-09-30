using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopMovement : IMovement 
{
    public Vector2 LastInput { get; private set; }

    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Vector2 direction = moveAction.ReadValue<Vector2>() * speed;
        LastInput = direction;
        rigidbody.AddForce(direction.x, 0, direction.y);
        Debug.Log(direction);
    }

 
}
