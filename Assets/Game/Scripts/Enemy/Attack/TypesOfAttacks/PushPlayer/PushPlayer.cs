using UnityEngine;

public class PushPlayer : PushObject
{
    [SerializeField] private float _pushForce;

    public void SetStartForce(float pushForce)
    {
        _pushForce += pushForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            Push(player.gameObject, gameObject, _pushForce);
    }
}
