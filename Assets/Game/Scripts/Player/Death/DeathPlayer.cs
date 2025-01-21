using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;

    private Rigidbody _rigidbody;
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

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
            Debug.Log("Death");
        }
    }
}
