using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private Vector3 _startPosition;

    private void OnEnable()
    {
        _restartLevel.OnRestartedLevel += RestartPosition;
        _loadLevel.OnLevelLoaded += RestartPosition;
    }

    private void OnDisable()
    {
        _restartLevel.OnRestartedLevel -= RestartPosition;
        _loadLevel.OnLevelLoaded -= RestartPosition;
    }

    private void RestartPosition()
    {
        transform.position = _startPosition;
    }
}
