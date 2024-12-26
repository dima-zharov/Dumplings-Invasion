using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _barrierX;
    private float _barrierMinZ;
    private float _barrierMaxZ;
    private float _constYPosition;
    private Vector3 _offsetPosition;

    private void Start()
    {
        //_offsetPosition = transform.position - _player.transform.position;
        _offsetPosition = new Vector3(transform.position.x - _player.transform.position.x, transform.position.y, transform.position.z - _player.transform.position.z);

        _barrierX = 1.5f;
        _barrierMinZ = -16.5f;
        _barrierMaxZ = -13.5f;
        _constYPosition = 14.8f;
    }

    private void LateUpdate()
    {
        Follow();
        CheckPosition();
    }

    private void Follow()
    {
        //transform.position = _player.transform.position + _offsetPosition;
        transform.position = new Vector3(_player.transform.position.x + _offsetPosition.x, _constYPosition, _player.transform.position.z + _offsetPosition.z);
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
