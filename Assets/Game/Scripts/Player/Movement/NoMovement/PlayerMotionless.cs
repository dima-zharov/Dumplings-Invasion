using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMotionless : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeBeforeDeathText;
    [SerializeField] private DeathPlayer _deathPlayer;
    [SerializeField] private LoadLevel _loadLevel;

    private Rigidbody _rigidbody;

    private bool _wasContinueChancePanelShowed = false;
    private float _timeBeforeDeath = 3;
    private float _elapsedTime;
    private float _unitOfTime = 0.1f;
    private bool _isImmobility;
    private bool _isCountdownStarted;

    private Vector3 _currentVelocity => new Vector3(Mathf.Round(_rigidbody.velocity.x), Mathf.Round(_rigidbody.velocity.y), Mathf.Round(_rigidbody.velocity.z));
    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += ResetContinueChancePanelState;
    }
    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= ResetContinueChancePanelState;
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CheckImmobility() && !_isCountdownStarted && _deathPlayer.IsAlive && !_loadLevel.IsLevelLoading)
            StartCoroutine(TimerImmobility());
    }

    private bool CheckImmobility()
    {
        if (_currentVelocity == Vector3.zero) 
            _isImmobility = true;
        else 
            _isImmobility = false;

        return _isImmobility;
    }

    private void CheckTimeOfDeath()
    {
        if (_elapsedTime >= 3)
        {
            _timeBeforeDeath -= _unitOfTime;
            _timeBeforeDeathText.text = _timeBeforeDeath.ToString("0.0");
        }

    }

    private void ResetContinueChancePanelState()
    {
        _wasContinueChancePanelShowed = false;
    }
    private void ResumeValues()
    {
        _elapsedTime = 0;
        _timeBeforeDeath = 3;
        _timeBeforeDeathText.text = "";
    }

    private IEnumerator TimerImmobility()
    {
        _isCountdownStarted = true;

        while (_isImmobility)
        {
            yield return new WaitForSeconds(_unitOfTime);
            _elapsedTime += _unitOfTime;

            CheckTimeOfDeath();

            if (_elapsedTime >= 6)
            {
                if (!_wasContinueChancePanelShowed)
                    _deathPlayer.Kill();

                _wasContinueChancePanelShowed = true;

                break;
            }

        }

        _isCountdownStarted = false;
        ResumeValues();
    }
}
