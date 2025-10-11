using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("TutorialCompleted") == 1)
            SceneManager.LoadSceneAsync("Game");
        else
            SceneManager.LoadSceneAsync("Tutorial");
    }
}
