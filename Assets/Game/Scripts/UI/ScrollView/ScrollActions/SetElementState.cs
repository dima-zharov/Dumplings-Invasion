using UnityEngine;
using UnityEngine.UI;
public class SetElementState : MonoBehaviour, IScrollElement
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Image _image;
    [SerializeField] public int Id { get; set; }

    public void MakeElementAction()
    {
        SetImage(_sprite, _image);
    }

    public void SetImage(Sprite sprite, Image image)
    {
        GetImageData(sprite, image);
        _image.sprite = _sprite;
    }

    private void GetImageData(Sprite sprite, Image image)
    {
        _image = image;
        _sprite = sprite;
    }
}
