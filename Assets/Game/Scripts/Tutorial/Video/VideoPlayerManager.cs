using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
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
        bool hadError = false;
        VideoPlayer.ErrorEventHandler onError = (vp, msg) =>
        {
            hadError = true;
            Debug.LogError($"VideoPlayer error: {msg}");
        };

        _videoPlayer.errorReceived += onError;

        string streamingPath = Path.Combine(Application.streamingAssetsPath, fileName);
        string url = null;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            using (var uwr = UnityWebRequest.Get(streamingPath))
            {
                yield return uwr.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
                if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
#else
                if (uwr.isNetworkError || uwr.isHttpError)
#endif
                {
                    Debug.LogError($"Failed to get streaming asset: {uwr.error}  ({streamingPath})");
                    _videoPlayer.errorReceived -= onError;
                    yield break;
                }

                var data = uwr.downloadHandler.data;
                if (data == null || data.Length == 0)
                {
                    Debug.LogError("Downloaded video is empty.");
                    _videoPlayer.errorReceived -= onError;
                    yield break;
                }

                string dest = Path.Combine(Application.persistentDataPath, fileName);
                try
                {
                    File.WriteAllBytes(dest, data);
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Failed to write video file: " + e);
                    _videoPlayer.errorReceived -= onError;
                    yield break;
                }

                url = "file://" + dest;
            }
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            url = streamingPath; 
        }
        else
        {
            url = streamingPath.Contains("://") ? streamingPath : "file://" + streamingPath;
        }

        _videoPlayer.source = VideoSource.Url;
        _videoPlayer.url = url;

        _videoPlayer.Prepare();
        yield return new WaitUntil(() => _videoPlayer.isPrepared || hadError);

        if (hadError)
        {
            Debug.LogError("Video failed to prepare: " + url);
        }
        else
        {
            _videoPlayer.Play();
            Debug.Log("Video playing: " + url);
        }

        _videoPlayer.errorReceived -= onError;
    }
}
