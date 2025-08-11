using System.Collections;
using TMPro;
using UnityEngine;

public abstract class PlayerMotioniessBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _timeBeforeDeathText;
    protected IDeathPlayer _deathPlayerBase;

    protected Rigidbody _rigidbody;

    protected bool _wasContinueChancePanelShowed = false;
    protected float _timeBeforeDeath = 3;
    protected float _elapsedTime;
    protected float _unitOfTime = 0.1f;
    protected bool _isImmobility;
    protected bool _isCountdownStarted;
    protected Vector3 _currentVelocity => new Vector3(Mathf.Round(_rigidbody.velocity.x), Mathf.Round(_rigidbody.velocity.y), Mathf.Round(_rigidbody.velocity.z));

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InitIDeathPlayer();
    }

    protected void Update()
    {
        CheckTimerBegin();
    }

    protected abstract void CheckTimerBegin();
    protected abstract void InitIDeathPlayer();

    protected bool CheckImmobility()
    {
        if (_currentVelocity == Vector3.zero)
            _isImmobility = true;
        else
            _isImmobility = false;

        return _isImmobility;
    }

    protected void CheckTimeOfDeath()
    {
        if (_elapsedTime >= 3)
        {
            _timeBeforeDeath -= _unitOfTime;
            _timeBeforeDeathText.text = _timeBeforeDeath.ToString("0.0");
        }

    }

    protected void ResetContinueChancePanelState()
    {
        _wasContinueChancePanelShowed = false;
    }
    protected void ResumeValues()
    {
        _elapsedTime = 0;
        _timeBeforeDeath = 3;
        _timeBeforeDeathText.text = "";
    }

    protected IEnumerator TimerImmobility()
    {
        _isCountdownStarted = true;

        while (_isImmobility)
        {
            yield return new WaitForSeconds(_unitOfTime);
            _elapsedTime += _unitOfTime;

            CheckTimeOfDeath();

            if (_elapsedTime >= 6)
            {
                KillPlayer();
                break;
            }

        }

        _isCountdownStarted = false;
        ResumeValues();
    }

    protected abstract void KillPlayer();
}
