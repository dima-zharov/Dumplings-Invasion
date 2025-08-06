using System.Collections;
using UnityEngine;

public class PotatoExplosionEffect : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(KillParticle());
    }

    private IEnumerator KillParticle()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
