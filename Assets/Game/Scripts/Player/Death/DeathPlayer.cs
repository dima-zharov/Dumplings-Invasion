using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private ContinueGameAttempts _gameAttempts;
    [SerializeField] private StartLevel _startLevel;
    [SerializeField] private ContinueGameAttempts _continueGameAttempts;
    [SerializeField] private int _deathLayerId;

    private bool _isAlive = false;

    public bool IsAlive => _isAlive;

    private void OnEnable() { _startLevel.OnStartedLevel += RevivePlayer; }
    private void OnDisable() { _startLevel.OnStartedLevel -= RevivePlayer; }

    public void RevivePlayer()
    {
        _isAlive = true;
    }

    public void Kill()
    {
        _loseSound.Play();
        _isAlive = false;
        _continueGameAttempts.CheckAttempts();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _deathLayerId && _isAlive)
        {   
            Kill();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == _deathLayerId && _isAlive)
        {
            Kill();
        }
    }
}
