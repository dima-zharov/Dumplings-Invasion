using System;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [SerializeField] private EffectsOnPlayerChangePlayer _playerChangedEffects;
    [SerializeField] private GameCompletion _gameCompletion;
    [SerializeField] private Player[] _players;
    [SerializeField] private LocationSystem _locationSystem;
    private bool _isGameJustBeginning = true;
    private const string PLAYER_ID_KEY = "PlayerId";
    public Player CurrentPlayer { get; private set; }

    public event Action<Player> OnChangedPlayer;
    
    private void OnEnable() => _locationSystem.OnChangedLocation += Change;
    private void OnDisable() => _locationSystem.OnChangedLocation -= Change;

    public void Change(Location location)
    {
        if (!_gameCompletion.IsEndlessModeEnable)
        {
            TrySwitchPlayer(location.LocationID);
            OnChangedPlayer?.Invoke(CurrentPlayer);
            if(!_isGameJustBeginning)
                _playerChangedEffects.MakeParticles(CurrentPlayer.transform.position);
            _isGameJustBeginning = false;
        }
    }

    public void Change(int PlayerNumber)
    {
        TrySwitchPlayer(PlayerNumber);
        OnChangedPlayer?.Invoke(CurrentPlayer);
    }

    private void SwitchPlayer(int playerNumber)
    {
        Player newPlayer = _players[playerNumber - 1];
        newPlayer.transform.position = CurrentPlayer.transform.position;

        CurrentPlayer.gameObject.SetActive(false);
        CurrentPlayer = newPlayer;
        CurrentPlayer.gameObject.SetActive(true);
    }

    private void TrySwitchPlayer(int playerNumber)
    {

        if (CurrentPlayer != null)
            SwitchPlayer(playerNumber);


        else
        {
            CurrentPlayer = _players[playerNumber - 1];
            CurrentPlayer.gameObject.SetActive(true);
        }
        PlayerPrefs.SetInt(PLAYER_ID_KEY, playerNumber - 1);
    }
}
