using System.Runtime.InteropServices;
using UnityEngine.UIElements;
using Zenject;

public class BuyPlayerUnlock : IUnlocker
{
    public string Description { get; private set; } = "������� � ������ �������?";
    public int PlayerIndex { get; private set; }
    private PlayersScroller _playerScroller;
    private bool hasItemBought = false;

    [Inject]
    public BuyPlayerUnlock(PlayersScroller players, int playerIndex)
    {
        _playerScroller = players;
        PlayerIndex = playerIndex;
    }


    public void Unlock()
    {
        Description  = "������� � ������ �������?";
        PlayerUnlockState.Unlock(PlayerIndex);
        _playerScroller.UnlockPlayer(PlayerIndex);
    }
    [DllImport("__Internal")]
    private static extern void MakePurchase();
    [DllImport("__Internal")]
    private static extern void CheckBought();

}
