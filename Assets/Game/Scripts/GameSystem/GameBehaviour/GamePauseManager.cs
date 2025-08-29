using UnityEditor;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private SoundSaveLoader _soundSaveLoader;
    [SerializeField] private AudioMixerController _musicController;
    [SerializeField] private ButtonTogle _musicState;

    private bool _isMusicUnMuting;


    private void OnApplicationPause(bool pauseStatus)
    {
        HandleFocusOrPause(!pauseStatus);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        HandleFocusOrPause(hasFocus);
    }

    public void Pause()
    {
        HandleFocusOrPause(false);
    }
    public void Resume()
    {
        HandleFocusOrPause(true);
    }

    private void HandleFocusOrPause(bool isActive)
    {
        if (!isActive)
        {
            _musicController.Mute();
            _isMusicUnMuting = true;
            _soundSaveLoader.SaveData();
            Time.timeScale = 0;
        }
        else
        {
            if (_isMusicUnMuting)
            {
                _musicController.UnMute();
                _isMusicUnMuting = false;
            }
            Time.timeScale = 1;
        }
    }
}
