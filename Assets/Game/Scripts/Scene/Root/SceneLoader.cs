using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("TutorialCompleted") == 1)
            SceneManager.LoadScene("Game");
        else
            SceneManager.LoadScene("Tutorial");
    }
}
