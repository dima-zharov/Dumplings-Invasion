using Zenject;

public class WatchAddUnlockPlayer : IUnlocker
{
    private PlayersScroller _playerScroller;

    [Inject]
    public WatchAddUnlockPlayer(PlayersScroller players)
    {
        _playerScroller = players;
    }

    public void Unlock()
    {
        _playerScroller.IncreasePlayersCount();
    }
}
