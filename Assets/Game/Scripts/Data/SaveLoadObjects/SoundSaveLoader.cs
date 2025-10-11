using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class SoundSaveLoader : MonoBehaviour
{
    [SerializeField] private ChangeSprite _changeSpriteSound;
    [SerializeField] private ChangeSprite _changeSpriteMusic;
    [SerializeField] private AudioMixerController _soundController;
    [SerializeField] private AudioMixerController _musicController;
    [SerializeField] private ButtonTogle _soundState;
    [SerializeField] private ButtonTogle _musicState;
    [SerializeField] private ButtonTogle _soundImage;
    [SerializeField] private ButtonTogle _musicImage;


    private string _sound = "Sound";
    private string _music = "Music";
    private string _imageSound = "SoundImage";
    private string _imageMusic = "MusicImage";
    private void Start()
    {
        if (PlayerPrefs.HasKey(_sound) && PlayerPrefs.HasKey(_music))
            LoadData();
    }

    public void SaveData()
    {
        int soundState = _soundState.IsActive ? 1 : 0;
        int musicState = _musicState.IsActive ? 1 : 0;
        int soundImage = _soundImage.IsActive ? 1 : 0;
        int musicImage = _musicImage.IsActive ? 1 : 0;

        PlayerPrefs.SetInt(_sound, soundState);
        PlayerPrefs.SetInt(_music, musicState);
        PlayerPrefs.SetInt(_imageSound, soundImage);
        PlayerPrefs.SetInt(_imageMusic, musicImage);
    }

    private void LoadData()
    {
        int sound = PlayerPrefs.GetInt(_sound);
        int music = PlayerPrefs.GetInt(_music);
        int soundImage = PlayerPrefs.GetInt(_imageSound);
        int musicImage = PlayerPrefs.GetInt(_imageMusic);

        _soundState.IsActive = sound != 1;
        _musicState.IsActive = music != 1;
        _soundImage.IsActive = soundImage != 1;
        _musicImage.IsActive = musicImage != 1;

        _soundController.SetAudioBehaviour();
        _musicController.SetAudioBehaviour();
        _changeSpriteSound.ChangeSpriteState();
        _changeSpriteMusic.ChangeSpriteState();
    }


}