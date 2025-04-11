using UnityEngine;

public class GameCompletionUIConroller : MonoBehaviour
{
    [SerializeField] private GameCompletion _gameCompletion;
    [SerializeField] private GameObject _gameCompletePanel;
    [SerializeField] private AppearanceAnimationDisableButton _gameCompleteInfo;
    [SerializeField] private GameObject _shopIcon;

    private void OnEnable()
    {
        _gameCompletion.OnGameCompleted += ActivatePanels;
    }
    private void OnDisable()
    {
        _gameCompletion.OnGameCompleted -= ActivatePanels;
    }


    public void ActivatePanels()
    {
        _gameCompletePanel.SetActive(true);
        _gameCompleteInfo.StartAnimation();
    }
}
