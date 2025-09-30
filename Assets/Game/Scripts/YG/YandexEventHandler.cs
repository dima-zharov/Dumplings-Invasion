using System;
using UnityEngine;

public class YandexEventHandler : MonoBehaviour
{
    [SerializeField] private event Action OnRewarded;
    [SerializeField] private event Action OnClosed;
    public void InitEvent(bool IsRewarded, Action Event)
    {
        if(IsRewarded)
            OnRewarded += Event;
        else
            OnClosed += Event;
    }

    public void Invoke(bool IsRewarded)
    {
        if(IsRewarded)
            OnRewarded?.Invoke();
        else
            OnClosed?.Invoke();
        Clear();
    }

    private void Clear()
    {
        OnRewarded = null;
        OnClosed = null;
    }
}
