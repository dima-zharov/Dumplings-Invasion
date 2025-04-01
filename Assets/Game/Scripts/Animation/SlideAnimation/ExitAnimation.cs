
using DG.Tweening;
using UnityEngine;

public class ExitAnimation : SlideAnimation
{
    protected override void MoveObject(Vector2 position)
    {
        _rectTransform.DOAnchorPos(position, _durationAnimation).SetEase(Ease.InOutSine).OnComplete(ResumePosition);
    }

    private void ResumePosition()
    {
        gameObject.SetActive(false);
        transform.position = _targetPosition;
    }
}
