using System.Collections;
using UnityEngine;

public class PlayerMotionless : PlayerMotioniessBase 
{ 
    [SerializeField] private LoadLevel _loadLevel;
    [SerializeField] private StartLevel _startLevel;
    private DeathPlayer _deathPlayer;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += ResetContinueChancePanelState;
        _loadLevel.OnLevelLoaded += StopTimerImmobility;
    }
    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= ResetContinueChancePanelState;
        _loadLevel.OnLevelLoaded -= StopTimerImmobility;
    }

    protected override void InitIDeathPlayer()
    {
        _deathPlayer = GetComponent<DeathPlayer>();
        _deathPlayerBase = _deathPlayer; 
    }

    protected override void CheckTimerBegin()
    {
        if (CheckImmobility() && !_isCountdownStarted && _deathPlayerBase.IsAlive && !_loadLevel.IsLevelLoading)
            StartCoroutine(TimerImmobility());

        Debug.Log(_loadLevel.IsLevelLoading);
    }
    protected override void KillPlayer()
    {
        if (!_wasContinueChancePanelShowed)
            _deathPlayerBase.Kill();

        _wasContinueChancePanelShowed = true;

    }

}
