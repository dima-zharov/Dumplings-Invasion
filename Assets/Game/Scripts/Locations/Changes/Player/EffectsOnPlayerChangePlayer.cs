using System.Collections;
using UnityEngine;

public class EffectsOnPlayerChangePlayer : MonoBehaviour
{
    [SerializeField] private int _particleDuration;
    [SerializeField] private GameObject _confettiParticlesPrefab;
    [SerializeField] private AudioSource _changePlayerSound;
    private ParticleSystem _confettiParticles;


    private void Start()
    {
        _confettiParticles = _confettiParticlesPrefab.GetComponent<ParticleSystem>();
    }

    public void MakeParticles(Vector3 particlePosition)
    {
        GameObject particleInstance = Instantiate(_confettiParticlesPrefab, particlePosition, Quaternion.identity);
        _changePlayerSound.Play();
        StartCoroutine(DestroyParticlesAfterPlay(particleInstance));

    }

    private IEnumerator DestroyParticlesAfterPlay(GameObject particleInstance)
    {
        yield return new WaitForSeconds(_particleDuration);
        Destroy(particleInstance);
    }
}
