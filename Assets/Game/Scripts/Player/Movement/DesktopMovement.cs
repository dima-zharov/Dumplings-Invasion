using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopMovement : IMovement 
{
    public bool IsMoving { get; set; }

    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Vector2 direction = moveAction.ReadValue<Vector2>() * speed;
        rigidbody.AddForce(direction.x, rigidbody.velocity.y, direction.y);
        IsMoving = direction == Vector2.zero ? false : true;
    }

 
}
