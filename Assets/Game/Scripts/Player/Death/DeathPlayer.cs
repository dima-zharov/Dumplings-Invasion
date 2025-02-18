using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private StartLevel _startLevel;

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
        _gameOver.FinishGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Death") && _isAlive)
            Kill();
    }
}
