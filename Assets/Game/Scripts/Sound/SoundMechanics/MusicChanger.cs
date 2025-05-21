using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _backgroundMusic;
    private AudioSource _audioSource;
    private int _clipIndex = 0;
    private void Start()
    {
        _audioSource = Singleton.Instance?.GetComponent<AudioSource>();
    }
    public void ChangeMusic()
    {
        if(_audioSource != null)
        {
            _audioSource.clip = _backgroundMusic[GetClipIndex()];
            _audioSource.Play();
        }
    }

    private int GetClipIndex()
    {
        _clipIndex++;
        if (_clipIndex > _backgroundMusic.Count - 1)
            _clipIndex = 0;
        return _clipIndex;

    }

}
