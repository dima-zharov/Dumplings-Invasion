using DG.Tweening;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private Vector3 _startPosition;

    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += Restart;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= Restart;
    }

    private void Restart()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        RestartPosition();

        _isAlive = true;
    }

    private void RestartPosition()
    {
        transform.DOJump(_startPosition, 4, 1, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
            _isAlive = false;
    }
}
