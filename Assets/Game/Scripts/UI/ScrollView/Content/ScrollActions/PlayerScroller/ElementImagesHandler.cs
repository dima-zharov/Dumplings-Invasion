using UnityEngine;
using UnityEngine.UI;
public class ElementImagesHandler : MonoBehaviour, IScrollElement
{
    private Sprite _foregroundSprite;
    private Sprite _stateSprite;
    private Image _foregroundImage;
    private Image _stateImage;

    public bool IsBlocked { get; private set; }
    public bool IsActive { get; private set; }



    public void MakeElementAction()
    {
        SetImage(_foregroundSprite, _foregroundImage);
        ChooseState(IsBlocked, IsActive, _stateSprite, _stateImage);
    }

    public void SetImage(Sprite sprite, Image image)
    {
        GetForegroundImageData(sprite, image);
        _foregroundImage.sprite = _foregroundSprite;
    }
    public void ChooseState(bool isBlocked, bool isActive, Sprite sprite, Image image)
    {
        IsBlocked = isBlocked;
        IsActive = isActive;
        GetStateImageData(sprite, image);
        _stateImage.sprite = sprite;

    }

    private void GetForegroundImageData(Sprite sprite, Image image)
    {
        _foregroundImage = image;
        _foregroundSprite = sprite;
    }


    private void GetStateImageData(Sprite sprite, Image image)
    {
        _stateImage = image;
        _stateSprite = sprite;
    }

}
