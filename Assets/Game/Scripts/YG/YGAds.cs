using UnityEngine;
using YG;

public class YGAds : MonoBehaviour
{
    [SerializeField] private LocationSystem _locationSystem;

    private void OnEnable()
    {
        _locationSystem.OnChangedLocationGlobal += TryShowFullScreenAd;
    }
    private void OnDisable()
    {
        _locationSystem.OnChangedLocationGlobal -= TryShowFullScreenAd;
    }
    public void TryShowFullScreenAd()
    {
        YandexGame.FullscreenShow();
    }

    public void ShowRewardedAd()
    {
        YandexGame.RewVideoShow(1);
    }
}