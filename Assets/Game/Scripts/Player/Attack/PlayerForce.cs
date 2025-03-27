using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    private float _startPushForce;
    private float _pushForce;

    public float PushForce => _pushForce;

    private void Start()
    {
        _startPushForce = 1;
        
        if (!PlayerPrefs.HasKey("firstOpen"))
            _pushForce = _startPushForce;
    }

    public void Init(float pushForce)
    {
        _pushForce = pushForce;
        Debug.Log("push force " + _pushForce);
    }

    public void UpgradeForce(float increaseForce)
    {
        _pushForce += _startPushForce * increaseForce;
    }
    
    
}
