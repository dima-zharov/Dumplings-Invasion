using System.Threading.Tasks;
using UnityEngine;

public class GameCompletionUIConroller : MonoBehaviour
{
    [SerializeField] private GameCompletion _gameCompletion;
    [SerializeField] private GameObject _gameCompletePanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private AppearanceAnimationDisableButton _gameCompleteInfo;
    [SerializeField] private ResizeAnimation _shopIcon;

    private void OnEnable()
    {
        _gameCompletion.OnGameCompleted += ActivatePanels;
        _gameCompletion.OnLoadCompletedGame += ActivateGameCompletePanel;
    }
    private void OnDisable()
    {
        _gameCompletion.OnGameCompleted -= ActivatePanels;
        _gameCompletion.OnLoadCompletedGame -= ActivateGameCompletePanel;
    }


    public void ActivatePanels()
    {
        StartPanelsAnimation(_shopPanel, _shopIcon);
        StartPanelsAnimation(_gameCompletePanel, _gameCompleteInfo);
    }

    private void ActivateGameCompletePanel()
    {
        _shopPanel.SetActive(true);
        _shopIcon.gameObject.SetActive(true);
    }

    private async void StartPanelsAnimation(GameObject parent, IAnimation animation)
    {
        parent.SetActive(true);
        await Task.Yield();
        animation.StartAnimation();
    }
}
