using DG.Tweening;
using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class ResizeAnimation : MonoBehaviour
{
    [field: SerializeField] public float DurationAnimation { get; private set; }
    [SerializeField] private float _resizeValue;
    [SerializeField] private ResizeTypes _resizeType;
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

    private void StartChangeSizeAnimation(Vector3 scaleToChange)
    {
        _UIObjectSize.DOScale(scaleToChange, DurationAnimation/2).OnComplete(SetBeginSize).SetEase(Ease.InOutSine);
    }

    private void SetBeginSize() => _UIObjectSize.DOScale(_startUISize, DurationAnimation / 2).SetEase(Ease.InOutSine);
}
