using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    [SerializeField] private float _startPushForce;
    
    private float _pushForce;

    public float PushForce => _pushForce;

    private void Start()
    {
        if (_pushForce < _startPushForce || !PlayerPrefs.HasKey("firstOpen"))
            _pushForce = _startPushForce;
    }

    public void Init(float pushForce)
    {
        _pushForce = pushForce;
    }

    public void UpgradeForce(float increaseForce)
    {
        _pushForce += increaseForce;
    }
    
    
}
