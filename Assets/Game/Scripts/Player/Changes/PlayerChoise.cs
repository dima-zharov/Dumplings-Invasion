using System.Collections.Generic;
using UnityEngine;

public class PlayerChoise : MonoBehaviour
{
    [SerializeField] GameCompletion _gameCompletion;
    [SerializeField] private List<Player> _players;
    [SerializeField] private PlayerChange _playerChange;
    
    private List<PlayerDataManager> _playersData = new();
    private List<PlayerForce> _playersForce = new();
    private List<DefenceAbility> _playersDefence = new();

    private void Start()
    {
        GetPlayersData();
    }
    public void ActivatePlayer(int playerId)
    {
        for (int i = 0; i < _players.Count; i++)
        {
            if (i == playerId)
            {
                if (_gameCompletion.IsEndlessModeEnable && _playerChange.CurrentPlayer != _players[i])
                {
                    _playersData[i].SetPlayerData(_playersForce[PlayerPrefs.GetInt("PlayerId")].PushForce, _playersDefence[PlayerPrefs.GetInt("PlayerId")].CurrentDefence);
                    Debug.Log(_playersDefence[PlayerPrefs.GetInt("PlayerId")].CurrentDefence + " " + _players[PlayerPrefs.GetInt("PlayerId")].name);
                    _playerChange.Change(i + 1);
                }
              
            }
        }
        
    }

    private void GetPlayersData()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            _playersData.Add(_players[i].gameObject.GetComponent<PlayerDataManager>());
            _playersForce.Add(_players[i].gameObject.GetComponent<PlayerForce>());
            _playersDefence.Add(_players[i].gameObject.GetComponent<DefenceAbility>());
        }
        for(int i = _playersData.Count - 1; i >= 0; i--)
        {
            if(i > _players.Count - 1)
                _playersData.Remove(_playersData[i]);
        }
    }
}
