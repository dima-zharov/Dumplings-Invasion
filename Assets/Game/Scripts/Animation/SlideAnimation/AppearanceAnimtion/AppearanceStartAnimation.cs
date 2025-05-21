using DG.Tweening;
using UnityEngine;
public class AppearanceStartAnimation : SlideAnimation
{
    [SerializeField] protected Vector2 _positionToMove;

    protected override void MoveObject(Vector2 position)
    {
        StartAppearaneAnimation(position);
    }

    public override void StartAnimation()
    {
        MoveObject(_positionToMove);
    }

    protected Tween StartAppearaneAnimation(Vector2 position)
    {
        return _rectTransform.DOAnchorPos(position, DurationAnimation)
           .SetEase(Ease.InOutSine)
           .OnUpdate(() =>
           {
               if (Vector2.Distance(_rectTransform.anchoredPosition, position) < 0.1f)
               {
                   _rectTransform.anchoredPosition = position;

               }
           });
    }
}
