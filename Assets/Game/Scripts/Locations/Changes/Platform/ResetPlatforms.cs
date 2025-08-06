using System.Collections.Generic;
using UnityEngine;

public class ResetPlatforms : MonoBehaviour
{
    [SerializeField] private List<PlatformData> _platforms;
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private NextLevel _nextLevel;
    [SerializeField] private LocationSystem _locations;
    private int _currentTileId;

    private void Start()
    {
        SetCurrentTile();
    }
    private void OnEnable()
    {
        _restartLevel.OnRestartedLevel += UpdatePlatforms;
        _nextLevel.OnCompleteLevel += SetCurrentTile;
    }
    private void OnDisable()
    {
        _restartLevel.OnRestartedLevel -= UpdatePlatforms;
        _nextLevel.OnCompleteLevel -= SetCurrentTile;
    }

    public void UpdatePlatforms()
    {
        foreach (PlatformData platform in _platforms) 
        {
            platform.SetTileToPlatform(_currentTileId);
        }
    }

    public void SetCurrentTile()
    {
        _currentTileId = _locations.CurrentLocationId - 1;
    }
}
