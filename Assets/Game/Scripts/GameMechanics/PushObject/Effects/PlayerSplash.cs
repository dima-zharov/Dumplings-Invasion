using System.Collections;
using UnityEngine;

public class PlayerSplash : MonoBehaviour
{
    [field:SerializeField] public float MinPushForce { get; private set; }
    [SerializeField] private GameObject _splashParticlesPrefab;
    private ParticleSystem _splashParticles;


    private void Start()
    {
        _splashParticles = _splashParticlesPrefab.GetComponent<ParticleSystem>();
    }

    public void MakeParticles(Vector3 particlePosition)
    {
        GameObject particleInstance = Instantiate(_splashParticlesPrefab, particlePosition, Quaternion.identity);

        StartCoroutine(DestroyParticlesAfterPlay(particleInstance));

    }

    private IEnumerator DestroyParticlesAfterPlay(GameObject particleInstance)
    {
        yield return new WaitForSeconds(_splashParticles.main.duration + _splashParticles.main.startLifetime.constantMax);
        Destroy(particleInstance);
    }
}
