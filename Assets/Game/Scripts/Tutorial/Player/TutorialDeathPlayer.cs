using UnityEngine;

public class TutorialDeathPlayer : MonoBehaviour
{
    [SerializeField] private LoadTutorialStep _loadTutorialStep;
    
    private bool _isAlive = true;
    
    public bool IsAlive => _isAlive;
    
    public void RevivePlayer() { _isAlive = true; }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death")  && _isAlive)
        {
            _isAlive = false;
            _loadTutorialStep.PlayerLose();
        }
    }
}
