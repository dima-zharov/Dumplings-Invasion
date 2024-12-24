using UnityEngine;

public class NextUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private SpawnEnemy _spawnEnemy;

    private void OnEnable()
    {
        _spawnEnemy.OnEnemiesDied += OpenUI;
    }

    private void OnDisable()
    {
        _spawnEnemy.OnEnemiesDied -= OpenUI;
    }

    public void OpenUI()
    {
        _panel.SetActive(true);
        _nextLevelButton.SetActive(true);
    }
}
