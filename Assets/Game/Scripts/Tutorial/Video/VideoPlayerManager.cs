using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    private List<string> _videoNames = new List<string>() { "BroccoliTutorial.mp4", "CarrotTutorial.mp4", "PotatoTutorial.mp4" };
    [SerializeField] private VideoPlayer _videoPlayer;

    private void Start()
    {
        ChoseVideoClip(0);
    }



    public void ChoseVideoClip(int clipId)
    {
        StartCoroutine(PlayFromStreamingAssets(_videoNames[clipId]));
    }

    private IEnumerator PlayFromStreamingAssets(string fileName)
    {
        while (!_videoPlayer.gameObject.activeSelf)
            yield return null;
        _videoPlayer.source = VideoSource.Url;
        _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        _videoPlayer.Prepare();
        while (!_videoPlayer.isPrepared)
            yield return null;
        _videoPlayer.Play();
    }

}
