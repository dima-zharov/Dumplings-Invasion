using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentLevelText;
    [SerializeField] private Levels _levels;
    [SerializeField] private LoadLevel _loadLevel;

    private void Awake()
    {
        ChangeLevel();
    }

    public void ChangeLevel()
    {
        _currentLevelText.text = _levels.CurrentLevel.ToString();
    }
}
