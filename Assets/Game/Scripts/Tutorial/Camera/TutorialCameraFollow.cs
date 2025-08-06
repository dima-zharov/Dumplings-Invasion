using UnityEngine;

public class TutorialCameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _offsetPosition;

    private float _barrierX = 1.5f;
    private float _barrierMinZ = -21;
    private float _barrierMaxZ = -18.5f;

    private void Start()
    {
        _offsetPosition = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        if (_player != null)
        {
            Follow();
            CheckPosition();
        }
    }

    private void Follow()
    {
        transform.position = _player.transform.position + _offsetPosition;
    }

    private void CheckPosition()
    {
        if (transform.position.x > _barrierX)
            transform.position = new Vector3(_barrierX, transform.position.y, transform.position.z);
        else if (transform.position.x < -_barrierX)
            transform.position = new Vector3(-_barrierX, transform.position.y, transform.position.z);

        if (transform.position.z > _barrierMaxZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, _barrierMaxZ);
        else if (transform.position.z < _barrierMinZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, _barrierMinZ);
    }
}
