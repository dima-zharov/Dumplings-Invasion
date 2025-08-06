using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class PlayCompleteLevelSound : MonoBehaviour
{
    [SerializeField] private NextLevel _nextLevel;
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _nextLevel.OnCompleteLevel += PlaySound;
    }
    private void OnDisable()
    {
        _nextLevel.OnCompleteLevel -= PlaySound;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        _audioSource.pitch = Random.Range(1f, 1.15f);
        _audioSource.Play();
    }

}
