using DG.Tweening;
using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class ResizeAnimation : MonoBehaviour
{
    [field: SerializeField] public float DurationAnimation { get; private set; }
    public bool isLooping = false;
    [SerializeField] private float _resizeValue;
    [SerializeField] private ResizeTypes _resizeType;
    private Sequence _scaleSequence;
    private Transform _objectSize;
    private RectTransform _UIObjectSize;
    private Vector3 _startUISize;
    private enum ResizeTypes
    {
        Grow,
        Minimize
    }

    private void Start()
    {
        _scaleSequence = DOTween.Sequence();
        _objectSize = GetComponent<RectTransform>();
        _UIObjectSize = _objectSize as RectTransform;
        _startUISize = _UIObjectSize.localScale;
    }

    public void StartAnimtion()
    {
        switch (_resizeType)
        {
            case (ResizeTypes.Grow):
                StartChangeSizeAnimation(new Vector3(_UIObjectSize.localScale.x + _resizeValue, _UIObjectSize.localScale.y + _resizeValue));
                break;
            case (ResizeTypes.Minimize):
                StartChangeSizeAnimation(new Vector3(_UIObjectSize.localScale.x - _resizeValue, _UIObjectSize.localScale.y - _resizeValue));
                break;
        }
    }

    public void StopAnimation()
    {
        DOTween.Kill(_UIObjectSize);
        SetBeginSize();
    }

    private void StartChangeSizeAnimation(Vector3 scaleToChange)
    {
        _scaleSequence.Append(_UIObjectSize.DOScale(scaleToChange, DurationAnimation/2).OnComplete(SetBeginSize).SetEase(Ease.InOutSine));
        if (isLooping)
            StartLoopAnimation();
    }

    private void SetBeginSize() => _scaleSequence.Append(_UIObjectSize.DOScale(_startUISize, DurationAnimation / 2).SetEase(Ease.InOutSine));

    private void StartLoopAnimation() => _scaleSequence.SetLoops(-1, LoopType.Restart);
}
