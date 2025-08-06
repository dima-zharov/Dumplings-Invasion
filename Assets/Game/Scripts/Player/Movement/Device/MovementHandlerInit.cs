using UnityEngine;
using Zenject;

public class MovementHandlerInit : MonoBehaviour
{
    private MovementHandler _movementHandler;

    public MovementHandler Handler => _movementHandler;

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
    }
}
