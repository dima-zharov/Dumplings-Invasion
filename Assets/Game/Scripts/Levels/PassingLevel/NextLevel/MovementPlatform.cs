using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private float _startPositionZ;
    [SerializeField] private float _endPositionZ;
    [SerializeField] private float _platformSpeed;
    [SerializeField] private LoadLevel _loadLevel;

    private bool _isMovement;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += StartMove;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= StartMove;
    }

    private void Update()
    {
        if (_isMovement)
            Move();
    }

    private void Move()
    {
        for (int i = 0; i < _platforms.Length; i++)
        {
            if (_platforms[i].transform.position.z <= _endPositionZ)
            {
                _platforms[i].transform.position = new Vector3(transform.position.x, transform.position.y, _startPositionZ);
                _isMovement = false;
                return;
            }

            _platforms[i].transform.Translate(new Vector3(0, 0, -1) * _platformSpeed * Time.deltaTime);
        }
    }

    private void StartMove()
    {
        _isMovement = true;
    }
}
