using UnityEngine;

public class TutorialDeathPlayer : MonoBehaviour, IDeathPlayer
{
    [SerializeField] private LoadTutorialStep _loadTutorialStep;

    public bool IsAlive { get; set; } = true;

    public void RevivePlayer() { IsAlive = true; }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death")  && IsAlive)
        {
           Kill();
        }
    }

    public void Kill()
    {
        IsAlive = false;
        _loadTutorialStep.PlayerLose();
    }
}
