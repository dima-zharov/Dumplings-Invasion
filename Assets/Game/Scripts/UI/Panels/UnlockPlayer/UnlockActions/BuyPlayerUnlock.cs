using UnityEngine;
using Zenject;

public class BuyPlayerUnlock : IUnlocker
{
    private PlayersScroller _playerScroller;

    [Inject]
    public BuyPlayerUnlock(PlayersScroller players)
    {
        _playerScroller = players;
    }

    public void Unlock()
    {
        _playerScroller.IncreasePlayersCount();
    }
}
