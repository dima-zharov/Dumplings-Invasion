using UnityEngine.UIElements;
using Zenject;

public class BuyPlayerUnlock : IUnlocker
{
    public string Description { get; private set; } = "Перейти в раздел покупок?";
    public int PlayerIndex {  get; private set; }   
    private PlayersScroller _playerScroller;

    [Inject]
    public BuyPlayerUnlock(PlayersScroller players, int playerIndex)
    {
        _playerScroller = players;
        PlayerIndex = playerIndex;
    }


    public void Unlock()
    {
        PlayerUnlockState.Unlock(PlayerIndex);
        _playerScroller.UnlockPlayer(PlayerIndex);
    }

}
