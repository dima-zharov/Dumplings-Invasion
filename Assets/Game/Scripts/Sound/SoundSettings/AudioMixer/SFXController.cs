using UnityEngine;
using UnityEngine.Audio;

public class SFXController : AudioMixerController
{
    private const string SFX_NAME = "SFX";

    protected override void SetParameterVolume(float volume)
    {
        bool success = _audioMixer.SetFloat(SFX_NAME, volume);
    }
}
