
using DG.Tweening;
using UnityEngine;

public class ExitAnimation : SlideAnimation
{
    protected override void MoveObject(Vector2 position)
    {
       StartExitAnimation(position).OnComplete(ResumePosition);
    }

    protected Tween StartExitAnimation(Vector2 position) => _rectTransform.DOAnchorPos(position, DurationAnimation).SetEase(Ease.InOutSine);

    protected void ResumePosition()
    {
        gameObject.SetActive(false);
        transform.position = _targetPosition;
    }
}
