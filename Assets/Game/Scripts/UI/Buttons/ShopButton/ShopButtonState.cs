using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopButtonState : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private GameCompletion _gameCompletion;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += TryActivateButton;
    }
    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= TryActivateButton;
    }

    public void TryActivateButton()
    {
        if (_gameCompletion.IsEndlessModeEnable)
            gameObject.SetActive(true);
    }

    
}
