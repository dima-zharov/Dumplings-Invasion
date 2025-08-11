using UnityEngine;

public class DeathPlayer : MonoBehaviour, IDeathPlayer
{
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private ContinueGameAttempts _gameAttempts;
    [SerializeField] private StartLevel _startLevel;
    [SerializeField] private ContinueGameAttempts _continueGameAttempts;
    [SerializeField] private int _deathLayerId;

    public bool IsAlive { get; set; } = false;


    private void OnEnable() { _startLevel.OnStartedLevel += RevivePlayer; }
    private void OnDisable() { _startLevel.OnStartedLevel -= RevivePlayer; }

    public void RevivePlayer()
    {
        IsAlive = true;
    }

    public void Kill()
    {
        _loseSound.Play();
        IsAlive = false;
        _continueGameAttempts.CheckAttempts();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _deathLayerId && IsAlive)
        {   
            Kill();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == _deathLayerId && IsAlive)
        {
            Kill();
        }
    }
}
