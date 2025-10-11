using UnityEngine;
using YG;

public class YGAds : MonoBehaviour
{
    public void TryShowFullScreenAd()
    {
        YG2.InterstitialAdvShow();
    }

    public void ShowRewardedAd(string rewardId)
    {
        YG2.RewardedAdvShow(rewardId);
    }
}