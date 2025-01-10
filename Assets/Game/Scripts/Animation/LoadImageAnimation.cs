using DG.Tweening;
using UnityEngine;

public class LoadImageAnimation : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;
    private RectTransform _imageTransform;
    private float _imagePosition;
    private float _imageFirstPositionX;

    private void Start()
    {
        _imageTransform = GetComponent<RectTransform>();
        _imagePosition = _imageTransform.offsetMin.x;
        _imageFirstPositionX = _imageTransform.offsetMin.x;
    }
    public void PlayAnimation()
    {
        _imageTransform.DOMoveX(_imagePosition - _imagePosition * 2, _animationSpeed);
        _imageTransform.offsetMin.Set(_imageFirstPositionX, _imageTransform.position.y);
    }
}
