using System;
using UnityEngine;
using YG;

public class FullScreenAdShowTimer : MonoBehaviour
{
    [SerializeField] private float _timerDuration = 120f;
    [SerializeField] private YGAds _ygAds; 
    [SerializeField] LevelTransition _levelTransition;
    private bool _isRunning = true;
    private float _remaining;
    private void OnEnable()
    {
        _levelTransition.OnCompleteTransition += ShowAd;
    }
    private void OnDisable()
    {
        _levelTransition.OnCompleteTransition -= ShowAd;
    }

    private void Start()
    {
        _remaining = _timerDuration;
        _isRunning = true;
    }

    private void Update()
    {
        if(_remaining < 0)
        {
            _isRunning = false;
            _remaining = _timerDuration;
        }
        else if (_isRunning)
        {
            _remaining -= Time.unscaledDeltaTime;
        }

    }

    private void ShowAd()
    {
        if (!_isRunning)
        {
            _ygAds.TryShowFullScreenAd();
            _isRunning=true;
        }
    }
}
