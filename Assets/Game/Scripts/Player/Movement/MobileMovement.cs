using UnityEngine;
using UnityEngine.InputSystem;

public class MobileMovement : IMovement
{
    public bool IsMoving { get; set; }

    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Debug.Log("Mobile input");
    }
}
