using UnityEngine;

public class TutorialPlayerBlockMovement : MonoBehaviour
{
    private bool _isMoving;
    
    public bool IsMoving => _isMoving;

    public void EnablePlayerMovement(bool enable)
    {
        _isMoving = enable;
    }
}
