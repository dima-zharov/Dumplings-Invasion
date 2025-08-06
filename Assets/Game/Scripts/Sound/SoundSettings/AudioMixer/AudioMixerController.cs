using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioMixerController : MonoBehaviour
{
    [SerializeField] protected AudioMixer _audioMixer;
    [SerializeField] private ButtonTogle _buttonTogle;

    public void SetAudioBehaviour()
    {
        _buttonTogle.TogleState(Mute, UnMute);
    }
    public void Mute()
    {
        SetParameterVolume(-80f);
    }

    public void UnMute()
    {
        SetParameterVolume(0f);
    }


    protected abstract void SetParameterVolume(float volume);
}
