using UnityEngine;
using YG;

public class FullScreenAdShowTimer : MonoBehaviour
{
    [SerializeField] private float _timerDuration = 120f;
    [SerializeField] private YGAds _ygAds; 
    [SerializeField] LocationSystem _locationSystem;
    private bool _isRunning = true;
    private float _remaining;
    private void OnEnable()
    {
        _locationSystem.OnChangedLocationGlobal += ShowAd;
    }
    private void OnDisable()
    {
        _locationSystem.OnChangedLocationGlobal -= ShowAd;
    }

    private void Start()
    {
        _remaining = _timerDuration;
        _isRunning = true;
    }

    private void Update()
    {
        if(!_isRunning)
            return;


        _remaining -= Time.unscaledDeltaTime;
        if(_timerDuration < 0)
        {
            _remaining = _timerDuration;
            _isRunning=false;
        }

    }

    private void ShowAd()
    {
        if(!_isRunning)
            _ygAds.TryShowFullScreenAd();
        _isRunning=true;
    }
}
