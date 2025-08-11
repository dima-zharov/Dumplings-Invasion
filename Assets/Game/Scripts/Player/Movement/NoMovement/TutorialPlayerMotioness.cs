using UnityEngine;

public class TutorialPlayerMotioness : PlayerMotioniessBase
{
    [SerializeField] private LoadTutorialStep _tutorial;
    private TutorialDeathPlayer _tutorDethPlayer;
    protected override void InitIDeathPlayer()
    {
        _tutorDethPlayer = GetComponent<TutorialDeathPlayer>();
        _deathPlayerBase = _tutorDethPlayer;
    }
    protected override void CheckTimerBegin()
    {
        if (CheckImmobility() && !_isCountdownStarted && _deathPlayerBase.IsAlive && _tutorial.IsTutorialStepActive)
            StartCoroutine(TimerImmobility());
    }

    protected override void KillPlayer()
    {
        _deathPlayerBase?.Kill();
    }
}
