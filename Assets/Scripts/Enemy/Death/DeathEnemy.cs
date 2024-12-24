using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Death"))
            Destroy(gameObject);
    }
}
