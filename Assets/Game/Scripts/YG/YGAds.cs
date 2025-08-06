using UnityEngine;
using YG;

public class YGAds : MonoBehaviour
{
    public void TryShowFullScreenAd()
    {
        YandexGame.FullscreenShow();
    }

    public void ShowRewardedAd()
    {
        YandexGame.RewVideoShow(1);
    }
}