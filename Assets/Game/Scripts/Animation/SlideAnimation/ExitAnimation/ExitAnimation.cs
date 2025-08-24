using DG.Tweening;
using UnityEngine;

public class ExitAnimation : SlideAnimation
{
    private Tweener _tween;
    private Vector2 _startAnchoredPosition; 

    protected new void Awake()
    {
        base.Awake();
        _startAnchoredPosition = _rectTransform.anchoredPosition; 
    }

    protected override void MoveObject(Vector2 position)
    {
        if (_tween != null)
        {
            _tween.Kill();
            _tween = null;
        }

        _tween = StartExitAnimation(position);
        _tween.OnComplete(ResumePosition);
    }

    protected Tweener StartExitAnimation(Vector2 position) =>
        _rectTransform.DOAnchorPos(position, DurationAnimation).SetEase(Ease.InOutSine);

    protected void ResumePosition()
    {
        _rectTransform.anchoredPosition = _startAnchoredPosition;

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (_tween != null)
        {
            _tween.Kill();
            _tween = null;
        }
    }
}
