using UnityEngine;

public class SettingsButtonState : MonoBehaviour
{
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private StartLevel _startLevel;
    [SerializeField] private NextLevel _nextLevel;
    private ButtonState _buttonState;
    private ExitAnimation _exitAnimation;

    private void OnEnable()
    {
        _startLevel.OnStartedLevel += ChangeDisableState;
        _nextLevel.OnCompleteLevel += ChangeActiveState;
    }

    private void OnDisable()
    {
        _startLevel.OnStartedLevel -= ChangeDisableState;
        _nextLevel.OnCompleteLevel -= ChangeActiveState;
    }

    private void Start()
    {
        _buttonState = _settingsButton.GetComponent<ButtonState>();
        _exitAnimation = _settingsButton.GetComponent<ExitAnimation>();
    }

    private void ChangeActiveState() => _settingsButton.SetActive(true);
    

    private void ChangeDisableState()
    {
        _exitAnimation.StartAnimation();
        _buttonState.DisableButton();
    }
    
}
