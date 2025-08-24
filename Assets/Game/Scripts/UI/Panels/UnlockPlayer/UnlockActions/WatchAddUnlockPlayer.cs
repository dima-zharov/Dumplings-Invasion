using System.Runtime.InteropServices;
using UnityEngine;
using YG;
using Zenject;

public class WatchAddUnlockPlayer : MonoBehaviour, IUnlocker
{
    public string Description { get; private set; } = "ќткрыть персонажа за просмотр рекламы? \n (осталось 2)";

    public int PlayerIndex { get; private set; }

    private PlayersScroller _playerScroller;
    private int _tryesToUnlock = 2;

    [DllImport("__Internal")]
    private static extern void WatchAddGetPlayerExtern();

    [Inject]
    public WatchAddUnlockPlayer(PlayersScroller players, int playerIndex)
    {
        _playerScroller = players;
        PlayerIndex = playerIndex;
    }

    public void Unlock()
    {
        WatchAddGetPlayerExtern();

    }

    public void WatchAddGetPlayer()
    {
        Debug.Log($"WatchAddGetPlayer() called, tries = {_tryesToUnlock}, PlayerIndex={PlayerIndex}");
        if (_tryesToUnlock == 1)
        {
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
