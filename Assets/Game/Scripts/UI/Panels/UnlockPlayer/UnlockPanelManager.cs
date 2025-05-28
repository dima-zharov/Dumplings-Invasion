using TMPro;
using UnityEngine;

public class UnlockPanelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unlockIhfo;
    [SerializeField] private AppearanceAnimationDisableButton  _startAnimation;
    private IUnlocker _unlocker;

    public void ChangeUnlockInfoData(IUnlocker unlockType)
    {
        _unlockIhfo.text = unlockType.Description;
        _unlocker = unlockType;
    }

    public void ActivatePanel()
    {
        _startAnimation.gameObject.SetActive(true);
        _startAnimation.StartAnimation();
    }

    public void UnlockPlayer()
    {
        _unlocker.Unlock();
    }


}
