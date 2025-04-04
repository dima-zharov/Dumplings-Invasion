using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private StartLevel _startLevel;
    [SerializeField] private ContinueGameAttempts _continueGameAttempts;

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
        _isAlive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Death") && _isAlive)
            _continueGameAttempts.CheckAttempts();
    }
}
