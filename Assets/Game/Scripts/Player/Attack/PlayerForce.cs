using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    [SerializeField] private float _startPushForce;
    
    public float PushForce { get; private set; }

    private void Awake()
    {
        if (PushForce < _startPushForce || !PlayerPrefs.HasKey("firstOpen"))
            PushForce = _startPushForce;
    }

    public void Init(float pushForce)
    {
        PushForce = pushForce;
    }

    public void UpgradeForce(float increaseForce)
    {
        PushForce += increaseForce;
    }
    
    
}
