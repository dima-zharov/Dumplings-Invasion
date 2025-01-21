using DG.Tweening;
using UnityEngine;

public class LoadImageAnimation : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;
    [SerializeField] private RestartLevel _restartLevel;

    private RectTransform _imageTransform;
    private float _imagePosition;

    private void OnEnable() => _restartLevel.OnRestartedLevel += PlayAnimation;
    private void OnDisable() => _restartLevel.OnRestartedLevel -= PlayAnimation;


    private void Start()
    {
        _imageTransform = GetComponent<RectTransform>();

        _imagePosition = _imageTransform.offsetMin.x;
    }

    public void PlayAnimation() => _imageTransform.DOMoveX(_imagePosition - _imagePosition / 2, _animationSpeed).SetLoops(2, LoopType.Yoyo);
    
}
