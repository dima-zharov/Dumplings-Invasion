using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    private const string VIDEO_URL_MAIN = "hhtps://dima-zharov.github.io/Dumplings-invasion-video-host";
    private List<string> videoUrls = new List<string>() { "BroccoliTutorial.mp4", "CarrotTutorial.mp4", "PotatoTutorial.mp4" };
    [SerializeField] private RawImage _videoRawImage;
    [SerializeField] private Sprite _noInternetConnectSprite;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private TutorialStep[] _steps;
    private void Start()
    {
        _videoPlayer.source = VideoSource.Url;
        ChoseVideoClip(0);
        PlayVideo();
    }

    public void PlayVideo()
    {
        _videoPlayer?.Play();
        if(Application.platform == RuntimePlatform.WebGLPlayer && !_videoPlayer.isPrepared)
            ShowError();
    }


    public void ChoseVideoClip(int clipId)
    {
        if(_videoPlayer.isPrepared)
            _videoPlayer.url = VIDEO_URL_MAIN + videoUrls[clipId];
        else
            _videoPlayer.clip = _steps[clipId].VideoClip;
    }

    private void ShowError()
    { 
        _videoRawImage.texture = _noInternetConnectSprite.texture;
    }
}
