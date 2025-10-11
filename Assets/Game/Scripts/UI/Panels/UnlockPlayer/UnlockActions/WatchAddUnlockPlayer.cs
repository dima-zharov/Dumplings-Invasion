using System.Runtime.InteropServices;
using UnityEngine;
using YG;
using Zenject;

public class WatchAddUnlockPlayer : IUnlocker
{
    public string Description { get; private set; } = "ќткрыть персонажа за просмотр рекламы? \n (осталось 2)";

    public int PlayerIndex { get; private set; }

    private string _unlockId;
    private YandexEventHandler _yandexEventHandler;
    private PlayersScroller _playerScroller;
    private int _tryesToUnlock = 2;

    [Inject]
    public WatchAddUnlockPlayer(PlayersScroller players, int playerIndex, string unlockId, YandexEventHandler yandexEventHandler)
    {
        _unlockId = unlockId;
        _playerScroller = players;
        PlayerIndex = playerIndex;
        _yandexEventHandler = yandexEventHandler;
    }

    public void Unlock()
    {
        YG2.RewardedAdvShow(_unlockId);
        _yandexEventHandler.InitEvent(true, WatchAddGetPlayer);

    }

    public void WatchAddGetPlayer()
    {
        Debug.Log($"WatchAddGetPlayer() called, tries = {_tryesToUnlock}, PlayerIndex={PlayerIndex}");
        if (_tryesToUnlock <= 1)
        {
            Debug.Log($"Get If - WatchAddGetPlayer() called, tries = {_tryesToUnlock}, PlayerIndex={PlayerIndex}");
            PlayerUnlockState.Unlock(PlayerIndex);
            _playerScroller.UnlockPlayer(PlayerIndex);
        }
        else
        {
            _tryesToUnlock--;
            Description = $"ќткрыть персонажа за просмотр рекламы? \n (осталось {_tryesToUnlock})";
        }
    }
}
