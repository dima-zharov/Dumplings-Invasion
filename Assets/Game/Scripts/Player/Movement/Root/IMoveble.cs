using UnityEngine;
using UnityEngine.InputSystem;

public interface IMovement
{ 
    public void Move(InputAction moveAction, float speed, Rigidbody rigidbody);
    Vector2 LastInput { get; }
}
