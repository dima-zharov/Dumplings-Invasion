using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField] private float _platformSpeed;
    [SerializeField] private NextLevel _nextLevel;
    [SerializeField] private LevelTransition _levelTransition;

    private float _startPositionZ = 0;
    private float _endPositionZ = -60;
    private bool _isMovement = false;

    private void OnEnable()
    {
        _nextLevel.OnCompleteLevel += StartMovement;
    }

    private void OnDisable()
    {
        _nextLevel.OnCompleteLevel -= StartMovement;
    }

    private void Update()
    {
        if (_isMovement)
            Move();
    }

    public void StartMovement() => _isMovement = true;



    private void Move()
    {
        transform.Translate(new Vector3(0, 0, -1) * _platformSpeed * Time.deltaTime);

        CheckPosition();
    }

    private void CheckPosition()
    {

        if (transform.position.z <= _endPositionZ)
        {
            _levelTransition.CompleteTransition();
            transform.position = new Vector3(transform.position.x, transform.position.y, _startPositionZ);
            _isMovement = false;

        }
    }
    
}
