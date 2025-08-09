using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public class BuyPlayerUnlock : MonoBehaviour, IUnlocker
{
    public string Description { get; private set; } = "Перейти в раздел покупок?";
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

        MakePurchase();
        
    }
    [DllImport("__Internal")]
    private static extern void MakePurchase();

    private void BuyPlayer()
    {
        Description = "Перейти в раздел покупок?";
        PlayerUnlockState.Unlock(PlayerIndex);
        _playerScroller.UnlockPlayer(PlayerIndex);
    }
}
