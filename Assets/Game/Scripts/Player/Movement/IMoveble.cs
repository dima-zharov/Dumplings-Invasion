using UnityEngine;
using UnityEngine.InputSystem;

public interface IMovement
{ 
    public bool IsMoving { get; set; }
    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody);
}
