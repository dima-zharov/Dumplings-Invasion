using TMPro;
using UnityEngine;

public class UnlockPanelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unlockIhfo;
    private IUnlocker _unlocker;

    public void ChangeUnlockInfoData(IUnlocker unlockType)
    {
        _unlockIhfo.text = unlockType.Description;
        _unlocker = unlockType;
    }

    public void ActivatePanel()
    {
        gameObject.SetActive(true);
    }

    public void UnlockPlayer()
    {
        _unlocker.Unlock();
    }


}
