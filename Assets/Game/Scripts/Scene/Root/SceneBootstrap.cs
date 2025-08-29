using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBootstrap : MonoBehaviour
{
    [SerializeField] private string bootstrapSceneName = "LoaderScene"; 

    void Awake()
    {
        if (Singleton.Instance == null)
        {
            SceneManager.LoadScene(bootstrapSceneName);
        }
    }
}