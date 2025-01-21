using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private float _startPositionZ;
    [SerializeField] private float _endPositionZ;
    [SerializeField] private float _platformSpeed;
    [SerializeField] private NextLevel _nextLevel;

    private bool _isMovement;

    private void OnEnable()
    {
        _nextLevel.OnCompleteLevel += StartMove;
    }

    private void OnDisable()
    {
        _nextLevel.OnCompleteLevel -= StartMove;
    }

    private void Update()
    {
        if (_isMovement)
            Move();
    }

    private void Move()
    {
        _platforms[0].transform.Translate(new Vector3(0, 0, -1) * _platformSpeed * Time.deltaTime);
        _platforms[1].transform.Translate(new Vector3(0, 0, -1) * _platformSpeed * Time.deltaTime);

        CheckStartPosition(_platforms[0]);
        CheckStartPosition(_platforms[1]);
    }

    private void CheckStartPosition(GameObject platform)
    {
        if (platform.transform.position.z <= _endPositionZ)
        {
            platform.transform.position = new Vector3(transform.position.x, transform.position.y, _startPositionZ);
            _isMovement = false;
        }
    }

    private void StartMove()
    {
        _isMovement = true;
    }
}
