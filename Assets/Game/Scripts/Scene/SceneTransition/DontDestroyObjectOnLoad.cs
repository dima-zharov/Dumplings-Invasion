using UnityEngine;

public class DontDestroyObjectOnLoad : MonoBehaviour
{
    private static bool _isCreated = false; 

    private void Awake()
    {

        if (_isCreated)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        _isCreated = true;
    }
}

