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
    private void Mute()
    {
        SetParameterVolume(-80f);
    }

    private void UnMute()
    {
        SetParameterVolume(0f);
    }


    protected abstract void SetParameterVolume(float volume);
}
