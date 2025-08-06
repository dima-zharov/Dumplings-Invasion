using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    private const string MUSIC_INDEX = "music_id";

    [SerializeField] private List<AudioClip> _backgroundMusic;
    private AudioSource _audioSource;
    private int _clipIndex = 0;
    private void Start()
    {
        _audioSource = Singleton.Instance?.GetComponent<AudioSource>();
        foreach (var clip in _backgroundMusic)
        {
            clip.LoadAudioData();
        }
        if(PlayerPrefs.HasKey(MUSIC_INDEX))
            _audioSource.clip = _backgroundMusic[PlayerPrefs.GetInt(MUSIC_INDEX)];
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
        PlayerPrefs.SetInt(MUSIC_INDEX, _clipIndex);
        return _clipIndex;

    }

}
