using YG;
using Zenject;

public class WatchAddUnlockPlayer : IUnlocker
{
    public string Description { get; private set; } = "ќткрыть персонажа за просмотр рекламы? \n (осталось 2)";

    public int PlayerIndex { get; private set; }

    private PlayersScroller _playerScroller;
    private int _tryesToUnlock = 2;

    [Inject]
    public WatchAddUnlockPlayer(PlayersScroller players, int playerIndex)
    {
        _playerScroller = players;
        PlayerIndex = playerIndex;
    }

    public void Unlock()
    {
        if(_tryesToUnlock == 1)
        {
            PlayerUnlockState.Unlock(PlayerIndex);
            _playerScroller.UnlockPlayer(PlayerIndex);
        }
        else
        {
            YandexGame.RewVideoShow(1);
            _tryesToUnlock--;
            Description = $"ќткрыть персонажа за просмотр рекламы? \n (осталось {_tryesToUnlock})";
        }
    }
}
