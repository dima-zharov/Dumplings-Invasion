using UnityEngine;

public class MovementHandler
{
    public IMovement Movement;

    public MovementHandler(IMovement movement) => Movement = movement;
    
}
