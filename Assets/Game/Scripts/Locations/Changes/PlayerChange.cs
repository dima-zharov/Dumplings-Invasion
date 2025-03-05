using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [SerializeField] private Player[] _players;
    [SerializeField] private LocationSystem _locationSystem;

    private Dictionary<int, Player> _playersDictionary;
    private Player _currentPlayer;

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
        OnChangedPlayer?.Invoke(_currentPlayer);
    }

    private void SwitchPlayer(int locationId)
    {
        Player newPlayer = _playersDictionary[locationId];
        newPlayer.transform.position = _currentPlayer.transform.position;

        _currentPlayer.gameObject.SetActive(false);
        _currentPlayer = newPlayer;
        _currentPlayer.gameObject.SetActive(true);
    }

    private void TrySwitchPlayer(int locationId)
    {
        if (_currentPlayer != null)
            SwitchPlayer(locationId);
        else
            _currentPlayer = _playersDictionary[locationId];
    }
}
