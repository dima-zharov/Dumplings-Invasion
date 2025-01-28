using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private NextLevel _nextLevel;
    [SerializeField] private float _startPositionZ;
    [SerializeField] private float _endPositionZ;
    [SerializeField] private float _platformSpeed;

    private float _averagePositionZ;
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

        CheckStartPosition(_platforms[0], _platforms[1]);
        CheckStartPosition(_platforms[1], _platforms[0]);
    }

    private void CheckStartPosition(GameObject platform1, GameObject platform2)
    {
        if (platform1.transform.position.z <= _endPositionZ)
        {
            platform1.transform.position = new Vector3(transform.position.x, transform.position.y, _startPositionZ);
            platform2.transform.position = new Vector3(transform.position.x, transform.position.y, _averagePositionZ);

            _isMovement = false;
        }
    }

    private void StartMove()
    {
        _isMovement = true;
    }
}
