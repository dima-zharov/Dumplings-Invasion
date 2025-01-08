using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;

    private int _currentLevel = 1;

    public int CurrentLevel => _currentLevel;

    public void Next()
    {
        _currentLevel++;
        _loadLevel.Load();
    }

}
