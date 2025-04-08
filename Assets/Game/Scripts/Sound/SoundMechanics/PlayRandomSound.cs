using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomSound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;
    private int _clipIsd;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }
    public void PlayRandomClip()
    {
        _clipIsd = Random.Range(0, _clips.Count);
        _audioSource.clip = _clips[_clipIsd];
        _audioSource.Play();
    }
    
}
