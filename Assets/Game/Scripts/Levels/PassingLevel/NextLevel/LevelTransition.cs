using System;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    public event Action OnCompleteTransition;

    public void CompleteTransition()
    {
        OnCompleteTransition?.Invoke();
    }
    
}
