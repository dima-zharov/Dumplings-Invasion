using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private StartLevel _startLevel;

    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void OnEnable() { _startLevel.OnStartedLevel += RevivePlayer; }
    private void OnDisable() { _startLevel.OnStartedLevel -= RevivePlayer; }

    public void RevivePlayer()
    {
        _isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Death") && _isAlive)
        {
            _isAlive = false;
            _gameOver.FinishGame();
        }
    }
}
