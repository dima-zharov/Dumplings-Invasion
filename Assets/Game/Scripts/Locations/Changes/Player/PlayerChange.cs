using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [SerializeField] private EffectsOnPlayerChangePlayer _playerChangedEffects;
    [SerializeField] private Player[] _players;
    [SerializeField] private LocationSystem _locationSystem;
    private bool _isGameJustBeginning = true;
    private const string PLATER_ID_KEY = "PlayerId";
    private Dictionary<int, Player> _playersDictionary;
    public Player CurrentPlayer { get; private set; }

    public event Action<Player> OnChangedPlayer;
    
    private void OnEnable() => _locationSystem.OnChangedLocation += Change;
    private void OnDisable() => _locationSystem.OnChangedLocation -= Change;

    private void Awake()
    {
        _playersDictionary = new Dictionary<int, Player>()
        {
            [1] = _players[0],
            [2] = _players[1],
            [3] = _players[2],
        };
    }

    public void Change(Location location)
    {
        TrySwitchPlayer(location.LocationID);
        OnChangedPlayer?.Invoke(CurrentPlayer);
        if(!_isGameJustBeginning)
            _playerChangedEffects.MakeParticles(CurrentPlayer.transform.position);
        _isGameJustBeginning = false;
    }

    public void Change(int PlayerNumber)
    {
        TrySwitchPlayer(PlayerNumber);
        OnChangedPlayer?.Invoke(CurrentPlayer);
    }

    private void SwitchPlayer(int locationId)
    {
        Player newPlayer = _playersDictionary[locationId];
        newPlayer.transform.position = CurrentPlayer.transform.position;

        CurrentPlayer.gameObject.SetActive(false);
        CurrentPlayer = newPlayer;
        CurrentPlayer.gameObject.SetActive(true);
    }

    private void TrySwitchPlayer(int locationId)
    {

        if (CurrentPlayer != null)
            SwitchPlayer(locationId);


        else
        {
            CurrentPlayer = _playersDictionary[locationId];
            CurrentPlayer.gameObject.SetActive(true);
            PlayerPrefs.SetInt(PLATER_ID_KEY, locationId - 1);
        }
    }
}
