using DG.Tweening;
using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    private float _animationTime = 0.3f;
    private void OnCollisionEnter(Collision collision)
    {
        DestroyPlayer(collision.gameObject.layer);

    }
    private void OnTriggerEnter(Collider collision)
    {
        DestroyPlayer(collision.gameObject.layer);
    }

    private void DestroyPlayer(int layer)
    {
        if (layer == LayerMask.NameToLayer("Death"))
        {
            ShrinkSize();
            Invoke(nameof(DestroyObject), _animationTime);
        }


    }

    private void DestroyObject() => Destroy(gameObject);

    private void ShrinkSize()
    {
        gameObject.transform.DOScale(Vector3.zero, _animationTime).SetEase(Ease.InOutQuad);
    }
}
