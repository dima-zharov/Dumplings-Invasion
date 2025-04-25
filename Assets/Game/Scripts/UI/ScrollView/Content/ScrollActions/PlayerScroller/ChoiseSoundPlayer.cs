using UnityEngine;

public class ChoiseSoundPlayer : MonoBehaviour, IScrollElement
{
    [SerializeField] private AudioSource _choiseSound;
    [SerializeField] private AudioSource _blockedChoiseSound;
    private ElementImagesHandler _imageHandler;

    public void MakeElementAction(){}

    public void PlayElementChoisenSound(ElementImagesHandler scrollElementHandler)
    {
        bool IsChoiseAvaliable = scrollElementHandler.IsActive;
        if(IsChoiseAvaliable)
            _choiseSound.Play();
        else
            _blockedChoiseSound.Play();
    }

    public void InitializeData(ElementImagesHandler scrollElementHandler)
    {
        _imageHandler = scrollElementHandler;
    }
}
