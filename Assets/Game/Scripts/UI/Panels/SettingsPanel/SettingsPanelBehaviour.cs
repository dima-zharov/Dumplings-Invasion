using UnityEngine;

[RequireComponent(typeof(SlideAnimation))]
public class SettingsPanelBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _leavePanel;
    private SlideAnimation _exitAnimatiion;
    private void Start()
    {
        _exitAnimatiion = GetComponent<ExitAnimation>();
    }

    public void PanelExit()
    {
        _exitAnimatiion.StartAnimation();
        Invoke(nameof(SetLeavePanelDisable), _exitAnimatiion.DurationAnimation);
    }

    private void SetLeavePanelDisable() => _leavePanel.SetActive(false);
}
