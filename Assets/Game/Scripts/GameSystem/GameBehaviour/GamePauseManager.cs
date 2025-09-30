using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GamePauseManager : MonoBehaviour
{
    private const string MusicKey = "Music";
    [SerializeField] private SoundSaveLoader soundSaveLoader;
    [SerializeField] private AudioMixerController musicController;
    [SerializeField] private ButtonTogle musicState;

    private bool _wasMusicPlaying;
    private bool _isPaused;

    private void OnApplicationPause(bool pauseStatus)
    {
        HandleFocusOrPause(!pauseStatus);
        
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if(!_isPaused)
            HandleFocusOrPause(hasFocus);
    }

    public void Pause()
    {
        HandleFocusOrPause(false);
        _isPaused = true;
    }
    public void Resume()
    {
        HandleFocusOrPause(true);
        _isPaused = false;
    }

    private void HandleFocusOrPause(bool isActive)
    {
        _wasMusicPlaying = PlayerPrefs.GetInt(MusicKey, 1) == 1;
        if (!isActive)
        {
            musicController.Mute();
            Time.timeScale = 0;
            soundSaveLoader?.SaveData();
        }
        else
        {
            if (_wasMusicPlaying)
            {
                musicController.UnMute();
            }
            Time.timeScale = 1;
        }
    }
}

