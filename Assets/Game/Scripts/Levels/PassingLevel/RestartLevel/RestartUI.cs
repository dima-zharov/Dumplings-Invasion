using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private DeathPlayer _deathPlayer;

    private void OnEnable()
    {
        _deathPlayer.OnPlayerDead += OpenUI;
    }

    private void OnDisable()
    {
        _deathPlayer.OnPlayerDead -= OpenUI;
    }

    private void OpenUI()
    {
        _panel.SetActive(true);
        _restartButton.SetActive(true);
    }
}
