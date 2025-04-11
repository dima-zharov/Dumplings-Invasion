using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 1)
            SceneManager.LoadScene("MainScene");
        else
            SceneManager.LoadScene("Tutorial");
    }
}
