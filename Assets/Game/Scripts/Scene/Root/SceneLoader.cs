using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("TutorialCompleted", 0);
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 1)
            SceneManager.LoadScene("Desctop");
        else
            SceneManager.LoadScene("Tutorial");
    }
}
