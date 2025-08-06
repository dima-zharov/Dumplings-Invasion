using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopMovement : IMovement 
{

    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Vector2 direction = moveAction.ReadValue<Vector2>() * speed;
        rigidbody.AddForce(direction.x, 0, direction.y);
    }

 
}
