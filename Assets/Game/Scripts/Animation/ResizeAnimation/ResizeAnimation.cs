using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ResizeAnimation : MonoBehaviour, IAnimation
{
    [field: SerializeField] public float DurationAnimation { get; private set; }
    [SerializeField] private bool _isLooping = false;
    [SerializeField] private float _resizeValue;
    [SerializeField] private ResizeTypes _resizeType;
    private Sequence _scaleSequence;
    private RectTransform _UIObjectSize;
    private Vector3 _startUISize;

    private enum ResizeTypes
    {
        Grow,
        Minimize
    }


    private void OnEnable()
    {
        if (_scaleSequence != null && !_scaleSequence.IsPlaying() && _isLooping)
            StartAnimation();
    }

    private void Start()
    {
        _UIObjectSize = GetComponent<RectTransform>();
        _startUISize = _UIObjectSize.localScale;
    }

    public void StartAnimation()
    {
        StopAnimation();
        _scaleSequence = DOTween.Sequence();

        Vector3 targetScale = _resizeType switch
        {
            ResizeTypes.Grow => _startUISize + Vector3.one * _resizeValue,
            ResizeTypes.Minimize => _startUISize - Vector3.one * _resizeValue,
            _ => _startUISize
        };

        _scaleSequence.Append(_UIObjectSize.DOScale(targetScale, DurationAnimation / 2).SetEase(Ease.InOutSine));
        _scaleSequence.Append(_UIObjectSize.DOScale(_startUISize, DurationAnimation / 2).SetEase(Ease.InOutSine));

        if (_isLooping)
            _scaleSequence.SetLoops(-1, LoopType.Restart);
        
    }

    public void ChangeLoopState(bool isLooping)
    {
        _isLooping = isLooping;
    }

    private void StopAnimation()
    {
        DOTween.Kill(_UIObjectSize);
        _scaleSequence?.Kill();

        _UIObjectSize.localScale = _startUISize;
    }
}