using UnityEngine;
using UnityEngine.InputSystem;

public class MobileMovement : IMovement
{

    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody)
    {
        Debug.Log("Mobile input");
    }
}
