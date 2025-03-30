using DG.Tweening;
using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    private float _animationTime = 0.3f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Death"))
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
