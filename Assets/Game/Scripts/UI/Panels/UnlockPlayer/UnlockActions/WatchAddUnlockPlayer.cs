using System.Runtime.InteropServices;
using UnityEngine;
using YG;
using Zenject;

public class WatchAddUnlockPlayer : IUnlocker
{
    public string Description { get; private set; } = "ќткрыть персонажа за просмотр рекламы? \n (осталось 2)";

    public int PlayerIndex { get; private set; }

    private YandexEventHandler _yandexEventHandler;
    private PlayersScroller _playerScroller;
    private int _tryesToUnlock = 2;

    [Inject]
    public WatchAddUnlockPlayer(PlayersScroller players, int playerIndex, YandexEventHandler yandexEventHandler)
    {
        _playerScroller = players;
        PlayerIndex = playerIndex;
        _yandexEventHandler = yandexEventHandler;
    }

    public void Unlock()
    {
        _yandexEventHandler.InitEvent(true, WatchAddGetPlayer);

    }

    public void WatchAddGetPlayer()
    {
        YandexGame.RewVideoShow(1);
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
