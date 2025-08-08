using System.Runtime.InteropServices;
using Zenject;

public class BuyPlayerUnlock : IUnlocker
{
    public string Description { get; private set; } = "������� � ������ �������?";
    public int PlayerIndex { get; private set; }
    private PlayersScroller _playerScroller;

    [Inject]
    public BuyPlayerUnlock(PlayersScroller players, int playerIndex)
    {
        _playerScroller = players;
        PlayerIndex = playerIndex;
    }


    public void Unlock()
    {
        Description  = "������� � ������ �������?";
        MakePurchase();
        PlayerUnlockState.Unlock(PlayerIndex);
        _playerScroller.UnlockPlayer(PlayerIndex);
    }
    [DllImport("__Internal")]
    private static extern void MakePurchase();
}
