using UnityEngine;

public class TutorialEnemyDeath : MonoBehaviour
{
    [SerializeField] private LoadTutorialStep _loadTutorialStep;
    [SerializeField] private LayerMask _deathLayer;

    private void Update()
    {
        if (_loadTutorialStep.IsEnemySpawn && _loadTutorialStep.EnemyObject == null)
            _loadTutorialStep.PlayerWin();
    }
}
