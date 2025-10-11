using YG;
using Zenject;

public class BuyPlayerUnlock : IUnlocker
{
    public string Description { get; private set; } = "Перейти в раздел покупок?";
    public int PlayerIndex { get; private set; }
    private string _purchaseId;
    private PlayersScroller _playerScroller;

    [Inject]
    public BuyPlayerUnlock(PlayersScroller players, int playerIndex, string purchaseId)
    {
        _purchaseId = purchaseId;
        _playerScroller = players;
        PlayerIndex = playerIndex;
    }

    public void Unlock()
    {
        YG2.BuyPayments(_purchaseId);
        YG2.onPurchaseSuccess += BuyPlayer;
    }
    public void BuyPlayer(string id)
    {
        PlayerUnlockState.Unlock(PlayerIndex);
        _playerScroller.UnlockPlayer(PlayerIndex);
    }
}
