using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highLevelGameOverPanel;
    [SerializeField] private TextMeshProUGUI _highLevelSettingsPanel;
    [SerializeField] private GameCompletion _gameCompletion;
    
    private int _highLevel;
    public int HighLevel => _highLevel;

    private void Awake()
    {
        _highLevel = PlayerPrefs.GetInt("BestScore");
        _gameCompletion.TryCompleteGame(_highLevel);
        _highLevelSettingsPanel.text = $"Ћучший счЄт: {_highLevel.ToString()}";
        _highLevelGameOverPanel.text = _highLevelSettingsPanel.text;
    }

    public void TryChangeHighLevel(int level)
    {
        if (level > _highLevel)
        {
            _highLevel = level;
            _highLevelSettingsPanel.text = $"Ћучший счЄт: {_highLevel.ToString()}";
            _highLevelGameOverPanel.text = _highLevelSettingsPanel.text;
            
            PlayerPrefs.SetInt("BestScore", _highLevel);
        }
    }
}
