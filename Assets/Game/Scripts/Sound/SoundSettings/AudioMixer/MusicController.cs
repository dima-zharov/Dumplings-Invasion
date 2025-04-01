using UnityEngine;

public class MusicController : AudioMixerController
{
    private const string MUSIC_NAME = "Music";

    protected override void SetParameterVolume(float volume)
    {
        _audioMixer.SetFloat(MUSIC_NAME, volume);
    }
}
