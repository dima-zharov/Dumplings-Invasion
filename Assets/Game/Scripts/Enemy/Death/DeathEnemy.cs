using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Death"))
            Destroy(gameObject);
    }
}
